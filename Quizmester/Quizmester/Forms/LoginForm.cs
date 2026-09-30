using MySql.Data.MySqlClient;
using Quizmester.Data;
using Quizmester.Forms;
using Quizmester.Services;

namespace Quizmester
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService = new AuthService();

        public LoginForm()
        {
            InitializeComponent();
            #if DEBUG
                btnTestLogin.Visible = true;
            #endif
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void btnTestDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                using MySqlConnection connection =
                    Database.GetConnection();

                connection.Open();

                MessageBox.Show(
                    "Database connection successful",
                    "Quizmesterr",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Database connection failed:\n" + ex.Message,
                    "Quizmester",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnOpenRegister_Click(object sender, EventArgs e)
        {
            using RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog(this);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _authService.Login(
                    txtUsername.Text,
                    txtPassword.Text);

                if (result.User == null)
                {
                    MessageBox.Show(
                        result.Message,
                        "Login",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                txtPassword.Clear();

                using MainMenuForm menu = new MainMenuForm(result.User);

                Hide();

                try
                {
                    menu.ShowDialog(this);
                }
                finally
                {
                    // Restore the login window when the menu closes.
                    Show();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Unable to log in. Check your database connection.",
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnTestLogin_Click(object sender, EventArgs e)
        {
#if DEBUG
            const string testUsername = "aphroditesk.ss";

            try
            {
                UserRepository repository = new UserRepository();
                var user = repository.GetUserByUsername(testUsername);

                if (user == null || !user.IsActive)
                {
                    MessageBox.Show(
                        $"Create an active account named '{testUsername}' first.");
                    return;
                }

                // Development shortcut: intentionally bypass password verification.
                using MainMenuForm menu = new MainMenuForm(user);

                txtPassword.Clear();
                Hide();

                try
                {
                    menu.ShowDialog(this);
                }
                finally
                {
                    Show();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Test login failed. Check your database connection.",
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
#endif
        }
    }
}
