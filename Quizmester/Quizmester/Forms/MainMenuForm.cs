using Quizmester.Models;
using Quizmester.Services;

namespace Quizmester.Forms
{
    public partial class MainMenuForm : Form
    {
        private readonly User? _currentUser;
        private readonly RankService _rankService =
    new RankService();
        public MainMenuForm()
        {
            InitializeComponent();
        }

        public MainMenuForm(User user) : this()
        {
            _currentUser = user;
            lblWelcome.Text = $"Welcome, {_currentUser.Username}!";

            btnAdmin.Visible = user.IsActive && user.IsAdmin;
            LoadPlayerRank();
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

        private void LoadPlayerRank()
        {
            Rank rank =
                _rankService.GetRank(_currentUser.LP);

            lblRank.Text = rank.Name;

            lblLP.Text =
                $"{rank.LPIntoRank} LP";

            int maxLP = GetRankProgressMaximum(rank);

            pbRankProgress.Minimum = 0;
            pbRankProgress.Maximum = maxLP;

            pbRankProgress.Value =
                Math.Clamp(
                    rank.LPIntoRank,
                    0,
                    maxLP
                );

            lblLPProgress.Text =
                $"{rank.LPIntoRank} / {maxLP} LP";
        }

        private int GetRankProgressMaximum(Rank rank)
        {
            return rank.Name switch
            {
                "Platinum" => 400,
                "Diamond" => 400,
                _ => 100
            };
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            LoadPlayerRank();
        }

    }
}