using MySql.Data.MySqlClient;
using Quizmester.Models;

namespace Quizmester.Data
{
    public class QuestionRepository
    {
        public List<Question> GetQuestions(List<int>? categoryIds = null)
        {
            // null means General; an empty selection means no questions.
            if (categoryIds != null && categoryIds.Count == 0)
            {
                return new List<Question>();
            }

            using MySqlConnection connection = Database.GetConnection();
            connection.Open();

            string sql = """
                SELECT
                    q.question_id,
                    q.category_id,
                    q.question_text,
                    q.points,
                    q.time_limit_seconds,
                    q.is_active,
                    a.answer_id,
                    a.answer_text,
                    a.is_correct
                FROM questions q
                LEFT JOIN answers a ON a.question_id = q.question_id
                WHERE q.is_active = TRUE
                """;

            using MySqlCommand command = new MySqlCommand();
            command.Connection = connection;

            if (categoryIds != null)
            {
                List<string> parameterNames = new List<string>();

                for (int i = 0; i < categoryIds.Count; i++)
                {
                    string parameterName = $"@category{i}";
                    parameterNames.Add(parameterName);

                    command.Parameters.AddWithValue(
                        parameterName,
                        categoryIds[i]);
                }

                sql += "\nAND q.category_id IN (" +
                    string.Join(", ", parameterNames) + ")";
            }

            sql += "\nORDER BY q.question_id, a.answer_id;";
            command.CommandText = sql;

            Dictionary<int, Question> questions = new Dictionary<int, Question>();

            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int questionId = reader.GetInt32("question_id");

                // A joined question appears once per answer; create it only once.
                if (!questions.TryGetValue(questionId, out Question? question))
                {
                    question = new Question
                    {
                        QuestionId = questionId,
                        CategoryId = reader.GetInt32("category_id"),
                        QuestionText = reader.GetString("question_text"),
                        Points = reader.GetInt32("points"),
                        TimeLimitSeconds = reader.GetInt32("time_limit_seconds"),
                        IsActive = reader.GetBoolean("is_active")
                    };

                    questions.Add(questionId, question);
                }

                if (!reader.IsDBNull(reader.GetOrdinal("answer_id")))
                {
                    question.Answers.Add(new Answer
                    {
                        AnswerId = reader.GetInt32("answer_id"),
                        QuestionId = questionId,
                        AnswerText = reader.GetString("answer_text"),
                        IsCorrect = reader.GetBoolean("is_correct")
                    });
                }
            }

            return questions.Values.ToList();
        }
    }
}