using Quizmester.Models;
using Quizmester.Services;

namespace Quizmester.Forms
{
    public partial class MainMenuForm : Form
    {
        private readonly User? _currentUser;
        private readonly RankService _rankService =
    new RankService();

        private readonly RankIconService _rankIconService =
    new RankIconService();
        public MainMenuForm()
        {
            InitializeComponent();
        }

        public MainMenuForm(User user) : this()
        {
            _currentUser = user;
            label.Text = $"{_currentUser.Username}!";

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

            picRank.Image =
                _rankIconService.GetRankIcon(rank);

            UpdateLPProgress(rank);
        }

        private void UpdateLPProgress(Rank rank)
        {
            int lpNeeded;

            if (rank.Name.StartsWith("Iron") ||
                rank.Name.StartsWith("Bronze") ||
                rank.Name.StartsWith("Silver") ||
                rank.Name.StartsWith("Gold"))
            {
                lpNeeded = 100;
            }
            else if (rank.Name == "Platinum")
            {
                lpNeeded = 400;
            }
            else if (rank.Name == "Diamond")
            {
                lpNeeded = 400;
            }
            else
            {
                // Master is currently the highest rank.
                progressLP.Minimum = 0;
                progressLP.Maximum = 100;
                progressLP.Value = 100;

                lblLPProgress.Text =
                    $"{rank.LPIntoRank} LP";

                return;
            }

            progressLP.Minimum = 0;
            progressLP.Maximum = lpNeeded;

            progressLP.Value =
                Math.Clamp(
                    rank.LPIntoRank,
                    0,
                    lpNeeded
                );

            lblLPProgress.Text =
                $"{rank.LPIntoRank} / {lpNeeded} LP";
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