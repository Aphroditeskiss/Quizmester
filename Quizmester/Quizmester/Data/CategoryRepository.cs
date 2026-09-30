using MySql.Data.MySqlClient;
using Quizmester.Models;

namespace Quizmester.Data
{
    public class CategoryRepository
    {
        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            using MySqlConnection connection = Database.GetConnection();
            connection.Open();

            string sql = """
                SELECT category_id, name
                FROM categories
                ORDER BY name;
                """;

            using MySqlCommand command = new MySqlCommand(sql, connection);
            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                categories.Add(new Category
                {
                    CategoryId = reader.GetInt32("category_id"),
                    Name = reader.GetString("name")
                });
            }

            return categories;
        }
    }
}