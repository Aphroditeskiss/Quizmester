using MySql.Data.MySqlClient;
using Quizmester.Data;
using Quizmester.Models;

namespace Quizmester.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepository = new UserRepository();

        public (bool Success, string Message) Register(
            string username, string password, string confirmPassword)
        {
            username = (username ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(username))
                return (false, "Enter a username.");

            if (string.IsNullOrWhiteSpace(password))
                return (false, "Enter a password.");

            if (password.Length < 8)
                return (false, "Use a password with at least 8 characters.");

            // Password spaces are intentional, so only trim the username.
            if (password != confirmPassword)
                return (false, "The passwords do not match.");

            if (_userRepository.UsernameExists(username))
                return (false, "That username is already taken.");

            var passwordData = PasswordHasher.HashPassword(password);

            try
            {
                _userRepository.CreateUser(
                    username, passwordData.Hash, passwordData.Salt);
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                // A UNIQUE constraint catches registrations made at the same time.
                return (false, "That username is already taken.");
            }

            return (true, "Account created. You can now log in.");
        }

        public (User? User, string Message) Login(string username, string password)
        {
            username = (username ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
                return (null, "Enter your username and password.");

            var passwordData = _userRepository.GetPasswordData(username);

            if (passwordData == null)
                return (null, "Incorrect username or password.");

            bool passwordMatches = PasswordHasher.VerifyPassword(
                password, passwordData.Value.Hash, passwordData.Value.Salt);

            if (!passwordMatches)
                return (null, "Incorrect username or password.");

            User? user = _userRepository.GetUserByUsername(username);

            if (user == null)
                return (null, "Incorrect username or password.");

            if (!user.IsActive)
                return (null, "This account has been disabled.");

            return (user, "Login successful.");
        }
    }
}
