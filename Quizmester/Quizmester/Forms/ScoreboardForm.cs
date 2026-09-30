using MySql.Data.MySqlClient;
using Quizmester.Data;
using Quizmester.Models;

namespace Quizmester.Forms
{
    public partial class ScoreboardForm : Form
    {
        private readonly GameSessionRepository _gameSessionRepository =
            new GameSessionRepository();

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

            AddColumn("Position", nameof(ScoreboardEntry.Position));
            AddColumn("Username", nameof(ScoreboardEntry.Username));
            AddColumn("Score", nameof(ScoreboardEntry.Score));
        }

        private void AddColumn(string heading, string propertyName)
        {
            dgvScores.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = heading,
                DataPropertyName = propertyName,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                List<ScoreboardEntry> entries =
                    _gameSessionRepository.GetTopTen();

                dgvScores.DataSource = entries;

                if (entries.Count == 0)
                {
                    lblTitle.Text = "No scores yet — finish a quiz first!";
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

        private void btnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}