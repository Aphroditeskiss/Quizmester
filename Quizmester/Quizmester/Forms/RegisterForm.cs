using MySql.Data.MySqlClient;
using Quizmester.Services;

namespace Quizmester.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly AuthService _authService = new AuthService();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _authService.Register(
                    txtUsername.Text,
                    txtPassword.Text,
                    txtConfirmPassword.Text);

                if (!result.Success)
                {
                    MessageBox.Show(
                        result.Message,
                        "Registration",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                MessageBox.Show(
                    result.Message,
                    "Registration",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (MySqlException)
            {
                // Database failures should leave the form open for another attempt.
                MessageBox.Show(
                    "Registration could not be saved. Check that MySQL is " +
                    "running and the database is configured correctly.",
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}