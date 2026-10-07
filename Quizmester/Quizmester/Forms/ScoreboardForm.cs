using MySql.Data.MySqlClient;
using Quizmester.Data;
using Quizmester.Models;
using Quizmester.Services;

namespace Quizmester.Forms
{
    public partial class ScoreboardForm : Form
    {
        private readonly UserRepository _userRepository =
            new UserRepository();

        private readonly RankService _rankService =
            new RankService();

        public ScoreboardForm()
        {
            InitializeComponent();

            btnClose.Click += btnClose_Click;

            ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            dgvScores.AutoGenerateColumns = false;
            dgvScores.Columns.Clear();

            dgvScores.ReadOnly = true;
            dgvScores.AllowUserToAddRows = false;
            dgvScores.AllowUserToDeleteRows = false;
            dgvScores.RowHeadersVisible = false;
            dgvScores.MultiSelect = false;

            dgvScores.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvScores.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            AddColumn("Position", "Position");
            AddColumn("Username", "Username");
            AddColumn("Rank", "Rank");
            AddColumn("LP", "LP");
        }

        private void AddColumn(
            string heading,
            string propertyName)
        {
            dgvScores.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    HeaderText = heading,
                    DataPropertyName = propertyName,
                    SortMode =
                        DataGridViewColumnSortMode.NotSortable
                });
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                List<User> users =
                    _userRepository.GetTopTenByLP();

                var entries = users
                    .Select((user, index) =>
                    {
                        Rank rank =
                            _rankService.GetRank(user.LP);

                        return new
                        {
                            Position = index + 1,
                            Username = user.Username,
                            Rank = rank.Name,
                            LP = $"{rank.LPIntoRank} LP"
                        };
                    })
                    .ToList();

                dgvScores.DataSource = entries;

                if (entries.Count == 0)
                {
                    lblTitle.Text =
                        "No ranked players yet — finish a quiz first!";
                }
                else
                {
                    lblTitle.Text = "Top 10 Ranked Players";
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Unable to load the scoreboard. Check your database connection.",
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(
            object? sender,
            EventArgs e)
        {
            Close();
        }

        private void dgvScores_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }
    }
}