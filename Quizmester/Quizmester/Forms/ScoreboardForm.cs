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

        private readonly RankIconService _rankIconService =
            new RankIconService();

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

            // Make rows tall enough for the rank icon.
            dgvScores.RowTemplate.Height = 55;

            AddTextColumn(
                "Position",
                "Position"
            );

            AddImageColumn(
                "RankIcon"
            );

            AddTextColumn(
                "Username",
                "Username"
            );

            AddTextColumn(
                "Rank",
                "Rank"
            );

            AddTextColumn(
                "LP",
                "LP"
            );
        }

        private void AddTextColumn(
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
                }
            );
        }

        private void AddImageColumn(
            string propertyName)
        {
            DataGridViewImageColumn imageColumn =
                new DataGridViewImageColumn
                {
                    HeaderText = "",
                    DataPropertyName = propertyName,
                    ImageLayout =
                        DataGridViewImageCellLayout.Zoom,
                    SortMode =
                        DataGridViewColumnSortMode.NotSortable
                };

            dgvScores.Columns.Add(imageColumn);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadScoreboard();
        }

        private void LoadScoreboard()
        {
            try
            {
                List<User> users =
                    _userRepository.GetTopTenByLP();

                var entries = users
                    .Select((user, index) =>
                    {
                        Rank rank =
                            _rankService.GetRank(user.LP);

                        Image? rankIcon =
                            _rankIconService.GetRankIcon(rank);

                        return new
                        {
                            Position = index + 1,

                            RankIcon = rankIcon,

                            Username = user.Username,

                            Rank = rank.Name,

                            LP =
                                $"{rank.LPIntoRank} LP"
                        };
                    })
                    .ToList();

                dgvScores.DataSource = null;
                dgvScores.DataSource = entries;

                if (entries.Count == 0)
                {
                    lblTitle.Text =
                        "No ranked players yet — finish a quiz first!";
                }
                else
                {
                    lblTitle.Text =
                        "Top 10 Ranked Players";
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Unable to load the scoreboard. Check your database connection.",
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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