using MySql.Data.MySqlClient;
using Quizmester.Models;

namespace Quizmester.Data
{
    public class GameSessionRepository
    {
        public int Save(GameSession game)
        {
            using MySqlConnection connection = Database.GetConnection();
            connection.Open();

            string sql = """
                INSERT INTO game_sessions (user_id, score)
                VALUES (@userId, @score);
                """;

            using MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@userId", game.UserId);
            command.Parameters.AddWithValue("@score", game.Score);

            command.ExecuteNonQuery();

            return checked((int)command.LastInsertedId);
        }

        public List<ScoreboardEntry> GetTopTen()
        {
            List<ScoreboardEntry> entries = new List<ScoreboardEntry>();

            using MySqlConnection connection = Database.GetConnection();
            connection.Open();

            string sql = """
        SELECT
            g.game_session_id,
            u.username,
            g.score
        FROM game_sessions g
        JOIN users u ON u.user_id = g.user_id
        ORDER BY g.score DESC, g.game_session_id ASC
        LIMIT 10;
        """;

            using MySqlCommand command = new MySqlCommand(sql, connection);
            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                entries.Add(new ScoreboardEntry
                {
                    Position = entries.Count + 1,
                    GameSessionId = reader.GetInt32("game_session_id"),
                    Username = reader.GetString("username"),
                    Score = reader.GetInt32("score")
                });
            }

            return entries;
        }
    }
}