using MySql.Data.MySqlClient;
using Quizmester.Models;

namespace Quizmester.Data
{
    public class CategoryRepository //retrieve all categories from database
    {
        public List<Category> GetAll() //return a list of categories
        {
            List<Category> categories = new List<Category>();

            using MySqlConnection connection = Database.GetConnection(); //get database connection
            connection.Open();

            //get categories
            string sql = """ 
                SELECT category_id, name
                FROM categories
                ORDER BY name;
                """;

            using MySqlCommand command = new MySqlCommand(sql, connection); //create command
            using MySqlDataReader reader = command.ExecuteReader(); //run query

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