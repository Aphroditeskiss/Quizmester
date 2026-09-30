namespace Quizmester.Models
{
    // Represents one user retrieved from the database.
    public class User
    {
        public int UserId { get; set; }

        // An empty default avoids a null string before a value is assigned.
        public string Username { get; set; } = string.Empty;

        public string Role { get; set; } = "Player";

        // Later, an administrator can disable an account.
        public bool IsActive { get; set; }

        // This property is calculated from Role instead of stored separately.
        public bool IsAdmin
        {
            get
            {
                return Role == "Admin";
            }
        }
    }
}