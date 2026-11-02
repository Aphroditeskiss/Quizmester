using MySql.Data.MySqlClient;
using Quizmester.Forms;

namespace Quizmester.Data
{
    public class SpeedQuizRepository
    {
        public void Save(SpeedQuizResult result)
        {
            using MySqlConnection connection =
                Database.GetConnection();

            connection.Open();

            string sql = """
                INSERT INTO speed_quiz_results
                (
                    user_id,
                    completion_time_ms
                )
                VALUES
                (
                    @userId,
                    @completionTimeMs
                );
                """;

            using MySqlCommand command =
                new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue(
                "@userId",
                result.UserId
            );

            command.Parameters.AddWithValue(
                "@completionTimeMs",
                result.CompletionTimeMs
            );

            command.ExecuteNonQuery();
        }

        public int? GetFastestTime()
        {
            using MySqlConnection connection =
                Database.GetConnection();

            connection.Open();

            string sql = """
                SELECT completion_time_ms
                FROM speed_quiz_results
                ORDER BY completion_time_ms ASC
                LIMIT 1;
                """;

            using MySqlCommand command =
                new MySqlCommand(sql, connection);

            object? result =
                command.ExecuteScalar();

            if (result == null ||
                result == DBNull.Value)
            {
                return null;
            }

            return Convert.ToInt32(result);
        }

        public string? GetFastestPlayer()
        {
            using MySqlConnection connection =
                Database.GetConnection();

            connection.Open();

            string sql = """
                SELECT u.username
                FROM speed_quiz_results sqr

                INNER JOIN users u
                    ON sqr.user_id = u.user_id

                ORDER BY sqr.completion_time_ms ASC
                LIMIT 1;
                """;

            using MySqlCommand command =
                new MySqlCommand(sql, connection);

            object? result =
                command.ExecuteScalar();

            return result?.ToString();
        }
    }
}