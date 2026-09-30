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

            btnAdmin.Visible = user.IsActive && user.IsAdmin;

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Please log in before starting a quiz.");
                return;
            }

            using CategorySelectionForm categoryForm =
                new CategorySelectionForm(_currentUser);

            categoryForm.ShowDialog(this);
        }

        private void btnScoreboard_Click(object sender, EventArgs e)
        {
            using ScoreboardForm scoreboardForm = new ScoreboardForm();
            scoreboardForm.ShowDialog(this);
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (_currentUser == null ||
                !_currentUser.IsActive ||
                !_currentUser.IsAdmin)
            {
                MessageBox.Show("Administrator access is required.");
                return;
            }

            using AdminForm adminForm = new AdminForm(_currentUser);
            adminForm.ShowDialog(this);
        }
    }
}