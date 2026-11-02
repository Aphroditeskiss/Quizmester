// ========= IMPORTS =========
using Quizmester.Models;
using Quizmester.Services;

namespace Quizmester.Forms
{
    public partial class MainMenuForm : Form
    {
        // ========= READONLY =========
        private readonly User? _currentUser; //remember current user
        private readonly RankService _rankService = new RankService();
        private readonly RankIconService _rankIconService = new RankIconService();

        // ========= MAIN MENU FORM =========
        public MainMenuForm()
        {
            InitializeComponent();
        }

        public MainMenuForm(User user) : this()
        {
            _currentUser = user; //store user
            label.Text = $"{_currentUser.Username}!"; //put username on label

            btnAdmin.Visible = user.IsActive && user.IsAdmin;
            LoadPlayerRank();
        }

        // ========= BUTTONS =========
        private void btnLogout_Click(object sender, EventArgs e) //close main menu
        {
            Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)  //play quiz
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Please log in before starting a quiz.");
                return;
            }

            using CategorySelectionForm categoryForm = new CategorySelectionForm(_currentUser); //create category selection screen

            categoryForm.ShowDialog(this);
        }

        private void btnScoreboard_Click(object sender, EventArgs e) // open scoreboard
        {
            using ScoreboardForm scoreboardForm = new ScoreboardForm();
            scoreboardForm.ShowDialog(this);
        }

        private void btnAdmin_Click(object sender, EventArgs e) //open admin panel
        {
            if (_currentUser == null || //just in case a non-admin player tries to open the admin, show warning
                !_currentUser.IsActive ||
                !_currentUser.IsAdmin)
            {
                MessageBox.Show("Administrator access is required.");
                return;
            }

            using AdminForm adminForm = new AdminForm(_currentUser);
            adminForm.ShowDialog(this);
        }

        // ========= OTHER =========
        private void LoadPlayerRank() //load rank of the player
        {
            if (_currentUser == null)
            {
                btnAdmin.Visible = false;
                return;
            }

            Rank rank = _rankService.GetRank(_currentUser.LP); //figure out what information should be displayed based off lp

            lblRank.Text = rank.Name;

            lblLP.Text = $"{rank.LPIntoRank} LP";

            picRank.Image = _rankIconService.GetRankIcon(rank); //fetch appropriate image from icon service

            UpdateLPProgress(rank);
        }

        private void UpdateLPProgress(Rank rank)
        {
            int lpNeeded;

            if (rank.Name.StartsWith("Iron") || //iron through gold need 100 lp to rank up
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
                progressLP.Minimum = 0; //highest is master, bar = full
                progressLP.Maximum = 100;
                progressLP.Value = 100;

                lblLPProgress.Text = $"{rank.LPIntoRank} LP"; //show lp beyond master

                return;
            }

            progressLP.Minimum = 0;
            progressLP.Maximum = lpNeeded;

            progressLP.Value = //keep number in permitted range
                Math.Clamp(
                    rank.LPIntoRank,
                    0,
                    lpNeeded
                );

            lblLPProgress.Text = $"{rank.LPIntoRank} / {lpNeeded} LP";
        }    //show LP and initialize ranks

        protected override void OnActivated(EventArgs e) //refresh menu
        {
            base.OnActivated(e);

            LoadPlayerRank();
        }

    }
}