public (string Hash, string Salt)?
    GetPasswordData(string username)
{
    using MySqlConnection connection =
        Database.GetConnection();

    connection.Open();

    string sql = """
                SELECT
                    password_hash,
                    password_salt
                FROM users
                WHERE username = @username;
                """;

    using MySqlCommand command =
        new MySqlCommand(sql, connection);

    command.Parameters.AddWithValue(
        "@username",
        username
    );

    using MySqlDataReader reader =
        command.ExecuteReader();

    if (!reader.Read())
    {
        return null;
    }

    return (
        reader.GetString("password_hash"),
        reader.GetString("password_salt")
    );
}
    }
}