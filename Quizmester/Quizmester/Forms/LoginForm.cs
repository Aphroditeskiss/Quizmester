using MySql.Data.MySqlClient;
using Quizmester.Data;

namespace Quizmester
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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
            } catch (Exception ex)
            {
                MessageBox.Show(
                    "Database connection failed:\n" + ex.Message,
                    "Quizmester",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
