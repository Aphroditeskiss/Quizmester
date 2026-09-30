using MySql.Data.MySqlClient;
using Quizmester.Data;
using Quizmester.Models;

namespace Quizmester.Forms
{
    public partial class AdminForm : Form
    {
        private readonly User? _currentUser;

        private readonly QuestionRepository _questionRepository =
            new QuestionRepository();
        private readonly UserRepository _userRepository =
    new UserRepository();
        public AdminForm()
        {
            InitializeComponent();

            btnClose.Click += btnClose_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnRefreshUsers.Click += btnRefreshUsers_Click;

            ConfigureGrid();
            ConfigureUserGrid();
        }

        public AdminForm(User user) : this()
        {
            _currentUser = user;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!HasAdminAccess())
            {
                MessageBox.Show(
                    "Only administrators can open this screen.",
                    "Access denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            LoadQuestions();
            LoadUsers();
        }

        private bool HasAdminAccess()
        {
            return _currentUser != null &&
                   _currentUser.IsActive &&
                   _currentUser.IsAdmin;
        }

        private void ConfigureGrid()
        {
            dgvQuestions.AutoGenerateColumns = false;
            dgvQuestions.Columns.Clear();

            dgvQuestions.ReadOnly = true;
            dgvQuestions.AllowUserToAddRows = false;
            dgvQuestions.AllowUserToDeleteRows = false;
            dgvQuestions.RowHeadersVisible = false;
            dgvQuestions.MultiSelect = false;

            dgvQuestions.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvQuestions.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            AddTextColumn("ID", nameof(Question.QuestionId), 35);
            AddTextColumn("Question", nameof(Question.QuestionText), 250);
            AddTextColumn("Category ID", nameof(Question.CategoryId), 60);
            AddTextColumn("Points", nameof(Question.Points), 50);
            AddTextColumn("Seconds", nameof(Question.TimeLimitSeconds), 50);

            dgvQuestions.Columns.Add(new DataGridViewCheckBoxColumn
            {
                HeaderText = "Active",
                DataPropertyName = nameof(Question.IsActive),
                FillWeight = 45,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
        }

        private void AddTextColumn(
            string heading,
            string propertyName,
            float widthWeight)
        {
            dgvQuestions.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = heading,
                DataPropertyName = propertyName,
                FillWeight = widthWeight,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
        }

        private void LoadQuestions()
        {
            if (!HasAdminAccess())
            {
                return;
            }

            try
            {
                List<Question> questions =
                    _questionRepository.GetAllForManagement();

                dgvQuestions.DataSource = questions;
                lblTitle.Text = $"Question management ({questions.Count})";
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Unable to load questions. Check your database connection.",
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadQuestions();
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            if (!HasAdminAccess() || _currentUser == null)
            {
                MessageBox.Show("Administrator access is required.");
                return;
            }

            using AddQuestionForm form = new AddQuestionForm(_currentUser);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadQuestions();
            }
        }

        private void btnEditQuestion_Click(object sender, EventArgs e)
        {
            if (!HasAdminAccess() || _currentUser == null)
            {
                MessageBox.Show("Administrator access is required.");
                return;
            }

            if (dgvQuestions.CurrentRow?.DataBoundItem is not Question question)
            {
                MessageBox.Show("Select a question first.");
                return;
            }

            using AddQuestionForm form =
                new AddQuestionForm(_currentUser, question.QuestionId);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadQuestions();
            }
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (!HasAdminAccess() || _currentUser == null)
            {
                MessageBox.Show("Administrator access is required.");
                return;
            }

            if (dgvQuestions.CurrentRow?.DataBoundItem is not Question question)
            {
                MessageBox.Show("Select a question first.");
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                $"Delete this question and all its answers?\n\n" +
                $"{question.QuestionText}\n\nThis cannot be undone.",
                "Delete question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _questionRepository.DeleteQuestion(
                    question.QuestionId,
                    _currentUser.UserId);

                LoadQuestions();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                LoadQuestions();
            }
            catch (MySqlException ex)
            {
                string message = "The question could not be deleted.";

#if DEBUG
                message += $"\nMySQL error {ex.Number}: {ex.Message}";
#endif

                MessageBox.Show(
                    message,
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigureUserGrid()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear();

            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.MultiSelect = false;

            dgvUsers.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvUsers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = nameof(User.UserId),
                FillWeight = 40,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Username",
                DataPropertyName = nameof(User.Username),
                FillWeight = 150,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Role",
                DataPropertyName = nameof(User.Role),
                FillWeight = 70,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });

            dgvUsers.Columns.Add(new DataGridViewCheckBoxColumn
            {
                HeaderText = "Active",
                DataPropertyName = nameof(User.IsActive),
                FillWeight = 50,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
        }

        private void LoadUsers()
        {
            if (!HasAdminAccess())
            {
                return;
            }

            try
            {
                List<User> users = _userRepository.GetAll();

                dgvUsers.DataSource = users;
                lblUsers.Text = $"User accounts ({users.Count})";
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Unable to load users. Check your database connection.",
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefreshUsers_Click(object? sender, EventArgs e)
        {
            LoadUsers();
        }

        private void ChangeSelectedUserStatus(bool isActive)
        {
            if (!HasAdminAccess() || _currentUser == null)
            {
                MessageBox.Show("Administrator access is required.");
                return;
            }

            if (dgvUsers.CurrentRow?.DataBoundItem is not User selectedUser)
            {
                MessageBox.Show("Select a user first.");
                return;
            }

            if (selectedUser.UserId == _currentUser.UserId)
            {
                MessageBox.Show(
                    "You cannot change your own account's active status.");
                return;
            }

            if (selectedUser.IsActive == isActive)
            {
                MessageBox.Show(
                    isActive
                        ? "This account is already enabled."
                        : "This account is already disabled.");
                return;
            }

            string action = isActive ? "Enable" : "Disable";

            DialogResult confirmation = MessageBox.Show(
                $"{action} the account '{selectedUser.Username}'?",
                "Change account status",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _userRepository.SetActive(
                    selectedUser.UserId,
                    isActive,
                    _currentUser.UserId);

                LoadUsers();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                LoadUsers();
            }
            catch (MySqlException ex)
            {
                string message = "The account status could not be changed.";

#if DEBUG
                message += $"\nMySQL error {ex.Number}: {ex.Message}";
#endif

                MessageBox.Show(
                    message,
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDisableUser_Click(object sender, EventArgs e)
        {
            ChangeSelectedUserStatus(false);
        }

        private void btnEnableUser_Click(object sender, EventArgs e)
        {
            ChangeSelectedUserStatus(true);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!HasAdminAccess() || _currentUser == null)
            {
                MessageBox.Show("Administrator access is required.");
                return;
            }

            try
            {
                // Recheck permissions in case the account changed after login.
                User? admin =
                    _userRepository.GetUserByUsername(_currentUser.Username);

                if (admin == null || !admin.IsActive || !admin.IsAdmin)
                {
                    MessageBox.Show("An active administrator account is required.");
                    return;
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Unable to verify administrator access. " +
                    "Check your database connection.",
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            using RegisterForm form = new RegisterForm();
            form.Text = "Quizmester - Add player account";

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (!HasAdminAccess() || _currentUser == null)
            {
                MessageBox.Show("Administrator access is required.");
                return;
            }

            if (dgvUsers.CurrentRow?.DataBoundItem is not User selectedUser)
            {
                MessageBox.Show("Select a user first.");
                return;
            }

            if (selectedUser.UserId == _currentUser.UserId)
            {
                MessageBox.Show("You cannot delete your own account.");
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                $"Delete the account '{selectedUser.Username}'?\n\n" +
                "All saved games and scoreboard entries for this user " +
                "will also be deleted.\n\nThis cannot be undone.",
                "Delete user",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _userRepository.DeleteUser(
                    selectedUser.UserId,
                    _currentUser.UserId);

                LoadUsers();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                LoadUsers();
            }
            catch (MySqlException ex)
            {
                string message = "The account could not be deleted.";

#if DEBUG
                message += $"\nMySQL error {ex.Number}: {ex.Message}";
#endif

                MessageBox.Show(
                    message,
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}