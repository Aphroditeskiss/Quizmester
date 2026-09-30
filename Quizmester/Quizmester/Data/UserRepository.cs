using MySql.Data.MySqlClient;
using Quizmester.Models;
using System;

namespace Quizmester.Data
{

    public class UserRepository
    {
        public bool UsernameExists(string username)
        {

            using MySqlConnection connection = Database.GetConnection();
            connection.Open();

            string sql = """
                SELECT COUNT(*)
                FROM users
                WHERE username = @username;
                """;

            using MySqlCommand command = new MySqlCommand(sql, connection);


            command.Parameters.AddWithValue("@username", username);

            long count = Convert.ToInt64(command.ExecuteScalar());

            return count > 0;
        }

        public void CreateUser(
            string username,
            string passwordHash,
            string passwordSalt)
        {
            using MySqlConnection connection = Database.GetConnection();
            connection.Open();


            string sql = """
                INSERT INTO users
                (
                    username,
                    password_hash,
                    password_salt,
                    role,
                    is_active
                )
                VALUES
                (
                    @username,
                    @passwordHash,
                    @passwordSalt,
                    'Player',
                    TRUE
                );
                """;

            using MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@passwordHash", passwordHash);
            command.Parameters.AddWithValue("@passwordSalt", passwordSalt);


            command.ExecuteNonQuery();
        }

        public User? GetUserByUsername(string username)
        {
            using MySqlConnection connection = Database.GetConnection();
            connection.Open();

            string sql = """
                SELECT
                    user_id,
                    username,
                    role,
                    is_active
                FROM users
                WHERE username = @username;
                """;

            using MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@username", username);

            using MySqlDataReader reader = command.ExecuteReader();


            if (!reader.Read())
            {
                return null;
            }

            return new User
            {
                UserId = reader.GetInt32("user_id"),
                Username = reader.GetString("username"),
                Role = reader.GetString("role"),
                IsActive = reader.GetBoolean("is_active")
            };
        }

        public (string Hash, string Salt)? GetPasswordData(string username)
        {
            using MySqlConnection connection = Database.GetConnection();
            connection.Open();

            string sql = """
                SELECT
                    password_hash,
                    password_salt
                FROM users
                WHERE username = @username;
                """;

            using MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@username", username);

            using MySqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }


            return (
                Hash: reader.GetString("password_hash"),
                Salt: reader.GetString("password_salt")
            );
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();

            using MySqlConnection connection = Database.GetConnection();
            connection.Open();

            string sql = """
        SELECT user_id, username, role, is_active
        FROM users
        ORDER BY username;
        """;

            using MySqlCommand command = new MySqlCommand(sql, connection);
            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new User
                {
                    UserId = reader.GetInt32("user_id"),
                    Username = reader.GetString("username"),
                    Role = reader.GetString("role"),
                    IsActive = reader.GetBoolean("is_active")
                });
            }

            return users;
        }

        public void SetActive(int userId, bool isActive, int adminUserId)
        {
            if (userId == adminUserId)
            {
                throw new InvalidOperationException(
                    "You cannot change your own account's active status.");
            }

            using MySqlConnection connection = Database.GetConnection();
            connection.Open();

            using MySqlTransaction transaction = connection.BeginTransaction();

            string permissionSql = """
        SELECT COUNT(*)
        FROM users
        WHERE user_id = @adminUserId
          AND role = 'Admin'
          AND is_active = TRUE;
        """;

            using MySqlCommand permissionCommand =
                new MySqlCommand(permissionSql, connection, transaction);

            permissionCommand.Parameters.AddWithValue(
                "@adminUserId", adminUserId);

            if (Convert.ToInt32(permissionCommand.ExecuteScalar()) == 0)
            {
                throw new UnauthorizedAccessException(
                    "An active administrator account is required.");
            }

            string findSql = """
        SELECT user_id
        FROM users
        WHERE user_id = @userId
        FOR UPDATE;
        """;

            using MySqlCommand findCommand =
                new MySqlCommand(findSql, connection, transaction);

            findCommand.Parameters.AddWithValue("@userId", userId);

            if (findCommand.ExecuteScalar() == null)
            {
                throw new InvalidOperationException(
                    "This user no longer exists.");
            }

            string updateSql = """
        UPDATE users
        SET is_active = @isActive
        WHERE user_id = @userId;
        """;

            using MySqlCommand updateCommand =
                new MySqlCommand(updateSql, connection, transaction);

            updateCommand.Parameters.AddWithValue("@isActive", isActive);
            updateCommand.Parameters.AddWithValue("@userId", userId);

            updateCommand.ExecuteNonQuery();
            transaction.Commit();
        }

        public void DeleteUser(int userId, int adminUserId)
        {
            if (userId == adminUserId)
            {
                throw new InvalidOperationException(
                    "You cannot delete your own account.");
            }

            using MySqlConnection connection = Database.GetConnection();
            connection.Open();

            using MySqlTransaction transaction = connection.BeginTransaction();

            string permissionSql = """
        SELECT COUNT(*)
        FROM users
        WHERE user_id = @adminUserId
          AND role = 'Admin'
          AND is_active = TRUE;
        """;

            using MySqlCommand permissionCommand =
                new MySqlCommand(permissionSql, connection, transaction);

            permissionCommand.Parameters.AddWithValue(
                "@adminUserId", adminUserId);

            if (Convert.ToInt32(permissionCommand.ExecuteScalar()) == 0)
            {
                throw new UnauthorizedAccessException(
                    "An active administrator account is required.");
            }

            string findSql = """
        SELECT user_id
        FROM users
        WHERE user_id = @userId
        FOR UPDATE;
        """;

            using MySqlCommand findCommand =
                new MySqlCommand(findSql, connection, transaction);

            findCommand.Parameters.AddWithValue("@userId", userId);

            if (findCommand.ExecuteScalar() == null)
            {
                throw new InvalidOperationException(
                    "This user no longer exists.");
            }

            // Remove dependent games before deleting their owner.
            string deleteGamesSql = """
        DELETE FROM game_sessions
        WHERE user_id = @userId;
        """;

            using MySqlCommand gamesCommand =
                new MySqlCommand(deleteGamesSql, connection, transaction);

            gamesCommand.Parameters.AddWithValue("@userId", userId);
            gamesCommand.ExecuteNonQuery();

            string deleteUserSql = """
        DELETE FROM users
        WHERE user_id = @userId;
        """;

            using MySqlCommand userCommand =
                new MySqlCommand(deleteUserSql, connection, transaction);

            userCommand.Parameters.AddWithValue("@userId", userId);
            userCommand.ExecuteNonQuery();

            transaction.Commit();
        }
    }
}