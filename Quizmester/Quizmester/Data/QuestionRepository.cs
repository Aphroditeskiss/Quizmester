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

        public List<Question> GetAllForManagement()
        {
            List<Question> questions = new List<Question>();

            using MySqlConnection connection = Database.GetConnection();
            connection.Open();

            string sql = """
        SELECT
            question_id,
            category_id,
            question_text,
            points,
            time_limit_seconds,
            is_active
        FROM questions
        ORDER BY question_id;
        """;

            using MySqlCommand command = new MySqlCommand(sql, connection);
            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                questions.Add(new Question
                {
                    QuestionId = reader.GetInt32("question_id"),
                    CategoryId = reader.GetInt32("category_id"),
                    QuestionText = reader.GetString("question_text"),
                    Points = reader.GetInt32("points"),
                    TimeLimitSeconds = reader.GetInt32("time_limit_seconds"),
                    IsActive = reader.GetBoolean("is_active")
                });
            }

            return questions;
        }

        public void AddQuestion(Question question, int adminUserId)
        {
            if (string.IsNullOrWhiteSpace(question.QuestionText) ||
                question.Answers.Count != 4 ||
                question.Answers.Any(answer =>
                    string.IsNullOrWhiteSpace(answer.AnswerText)) ||
                question.Answers.Count(answer => answer.IsCorrect) != 1)
            {
                throw new ArgumentException(
                    "A question needs text, four answers, and one correct answer.");
            }

            using MySqlConnection connection = Database.GetConnection();
            connection.Open();

            using MySqlTransaction transaction = connection.BeginTransaction();

            string permissionSql = """
        SELECT COUNT(*)
        FROM users
        WHERE user_id = @userId
          AND role = 'Admin'
          AND is_active = TRUE;
        """;

            using MySqlCommand permissionCommand =
                new MySqlCommand(permissionSql, connection, transaction);

            permissionCommand.Parameters.AddWithValue("@userId", adminUserId);

            if (Convert.ToInt32(permissionCommand.ExecuteScalar()) == 0)
            {
                throw new UnauthorizedAccessException(
                    "An active administrator account is required.");
            }

            string questionSql = """
        INSERT INTO questions
            (category_id, question_text, points, time_limit_seconds, is_active)
        VALUES
            (@categoryId, @text, @points, @seconds, @active);
        """;

            using MySqlCommand questionCommand =
                new MySqlCommand(questionSql, connection, transaction);

            questionCommand.Parameters.AddWithValue("@categoryId", question.CategoryId);
            questionCommand.Parameters.AddWithValue("@text", question.QuestionText);
            questionCommand.Parameters.AddWithValue("@points", question.Points);
            questionCommand.Parameters.AddWithValue("@seconds", question.TimeLimitSeconds);
            questionCommand.Parameters.AddWithValue("@active", question.IsActive);

            questionCommand.ExecuteNonQuery();

            int questionId = checked((int)questionCommand.LastInsertedId);

            string answerSql = """
        INSERT INTO answers (question_id, answer_text, is_correct)
        VALUES (@questionId, @text, @correct);
        """;

            foreach (Answer answer in question.Answers)
            {
                using MySqlCommand answerCommand =
                    new MySqlCommand(answerSql, connection, transaction);

                answerCommand.Parameters.AddWithValue("@questionId", questionId);
                answerCommand.Parameters.AddWithValue("@text", answer.AnswerText);
                answerCommand.Parameters.AddWithValue("@correct", answer.IsCorrect);

                answerCommand.ExecuteNonQuery();
            }

            transaction.Commit();
        }

        public Question? GetById(int questionId)
        {
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
        WHERE q.question_id = @questionId
        ORDER BY a.answer_id;
        """;

            using MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@questionId", questionId);

            using MySqlDataReader reader = command.ExecuteReader();

            Question? question = null;

            while (reader.Read())
            {
                if (question == null)
                {
                    question = new Question
                    {
                        QuestionId = reader.GetInt32("question_id"),
                        CategoryId = reader.GetInt32("category_id"),
                        QuestionText = reader.GetString("question_text"),
                        Points = reader.GetInt32("points"),
                        TimeLimitSeconds = reader.GetInt32("time_limit_seconds"),
                        IsActive = reader.GetBoolean("is_active")
                    };
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

            return question;
        }

        public void UpdateQuestion(Question question, int adminUserId)
        {
            if (string.IsNullOrWhiteSpace(question.QuestionText) ||
                question.Answers.Count != 4 ||
                question.Answers.Any(answer =>
                    string.IsNullOrWhiteSpace(answer.AnswerText)) ||
                question.Answers.Count(answer => answer.IsCorrect) != 1)
            {
                throw new ArgumentException(
                    "A question needs text, four answers, and one correct answer.");
            }

            using MySqlConnection connection = Database.GetConnection();
            connection.Open();

            using MySqlTransaction transaction = connection.BeginTransaction();

            string permissionSql = """
        SELECT COUNT(*)
        FROM users
        WHERE user_id = @userId
          AND role = 'Admin'
          AND is_active = TRUE;
        """;

            using MySqlCommand permissionCommand =
                new MySqlCommand(permissionSql, connection, transaction);

            permissionCommand.Parameters.AddWithValue("@userId", adminUserId);

            if (Convert.ToInt32(permissionCommand.ExecuteScalar()) == 0)
            {
                throw new UnauthorizedAccessException(
                    "An active administrator account is required.");
            }

            string existsSql = """
        SELECT question_id
        FROM questions
        WHERE question_id = @questionId
        FOR UPDATE;
        """;

            using MySqlCommand existsCommand =
                new MySqlCommand(existsSql, connection, transaction);

            existsCommand.Parameters.AddWithValue(
                "@questionId", question.QuestionId);

            if (existsCommand.ExecuteScalar() == null)
            {
                throw new InvalidOperationException(
                    "This question no longer exists.");
            }

            string updateSql = """
        UPDATE questions
        SET category_id = @categoryId,
            question_text = @text,
            points = @points,
            time_limit_seconds = @seconds,
            is_active = @active
        WHERE question_id = @questionId;
        """;

            using MySqlCommand updateCommand =
                new MySqlCommand(updateSql, connection, transaction);

            updateCommand.Parameters.AddWithValue("@categoryId", question.CategoryId);
            updateCommand.Parameters.AddWithValue("@text", question.QuestionText);
            updateCommand.Parameters.AddWithValue("@points", question.Points);
            updateCommand.Parameters.AddWithValue("@seconds", question.TimeLimitSeconds);
            updateCommand.Parameters.AddWithValue("@active", question.IsActive);
            updateCommand.Parameters.AddWithValue("@questionId", question.QuestionId);

            updateCommand.ExecuteNonQuery();

            // Replace the answer set within the same transaction.
            string deleteSql = """
        DELETE FROM answers
        WHERE question_id = @questionId;
        """;

            using MySqlCommand deleteCommand =
                new MySqlCommand(deleteSql, connection, transaction);

            deleteCommand.Parameters.AddWithValue(
                "@questionId", question.QuestionId);

            deleteCommand.ExecuteNonQuery();

            string answerSql = """
        INSERT INTO answers (question_id, answer_text, is_correct)
        VALUES (@questionId, @text, @correct);
        """;

            foreach (Answer answer in question.Answers)
            {
                using MySqlCommand answerCommand =
                    new MySqlCommand(answerSql, connection, transaction);

                answerCommand.Parameters.AddWithValue(
                    "@questionId", question.QuestionId);
                answerCommand.Parameters.AddWithValue("@text", answer.AnswerText);
                answerCommand.Parameters.AddWithValue("@correct", answer.IsCorrect);

                answerCommand.ExecuteNonQuery();
            }

            transaction.Commit();
        }

        public void DeleteQuestion(int questionId, int adminUserId)
        {
            using MySqlConnection connection = Database.GetConnection();
            connection.Open();

            using MySqlTransaction transaction = connection.BeginTransaction();

            string permissionSql = """
        SELECT COUNT(*)
        FROM users
        WHERE user_id = @userId
          AND role = 'Admin'
          AND is_active = TRUE;
        """;

            using MySqlCommand permissionCommand =
                new MySqlCommand(permissionSql, connection, transaction);

            permissionCommand.Parameters.AddWithValue("@userId", adminUserId);

            if (Convert.ToInt32(permissionCommand.ExecuteScalar()) == 0)
            {
                throw new UnauthorizedAccessException(
                    "An active administrator account is required.");
            }

            string deleteAnswersSql = """
        DELETE FROM answers
        WHERE question_id = @questionId;
        """;

            using MySqlCommand answersCommand =
                new MySqlCommand(deleteAnswersSql, connection, transaction);

            answersCommand.Parameters.AddWithValue("@questionId", questionId);
            answersCommand.ExecuteNonQuery();

            string deleteQuestionSql = """
        DELETE FROM questions
        WHERE question_id = @questionId;
        """;

            using MySqlCommand questionCommand =
                new MySqlCommand(deleteQuestionSql, connection, transaction);

            questionCommand.Parameters.AddWithValue("@questionId", questionId);

            if (questionCommand.ExecuteNonQuery() == 0)
            {
                throw new InvalidOperationException(
                    "This question no longer exists.");
            }

            transaction.Commit();
        }
    }
}