namespace Quizmester.Models
{
    // Represents one user retrieved from the database.
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Role { get; set; } = "Player";

        public bool IsActive { get; set; }

        public int LP { get; set; }

        public bool IsAdmin
        {
            get
            {
                return Role == "Admin";
            }
        }
    }
}