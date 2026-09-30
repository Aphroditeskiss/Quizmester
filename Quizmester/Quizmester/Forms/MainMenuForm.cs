using Quizmester.Models;

namespace Quizmester.Forms
{
    public partial class MainMenuForm : Form
    {
        private readonly User? _currentUser;

        public MainMenuForm()
        {
            InitializeComponent();
        }

        public MainMenuForm(User user) : this()
        {
            _currentUser = user;
            lblWelcome.Text = $"Welcome, {_currentUser.Username}!";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            using CategorySelectionForm categoryForm =
            new CategorySelectionForm();

            categoryForm.ShowDialog(this);
        }
    }
}