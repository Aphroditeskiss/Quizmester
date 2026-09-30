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
    }
}