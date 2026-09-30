using MySql.Data.MySqlClient;
using Quizmester.Data;
using Quizmester.Models;

namespace Quizmester.Forms
{
    public partial class AddQuestionForm : Form
    {
        private readonly User? _currentUser;

        private readonly CategoryRepository _categoryRepository =
            new CategoryRepository();

        private readonly QuestionRepository _questionRepository =
            new QuestionRepository();

        private readonly int? _questionId;
        private bool _isActive = true;
        private int _timeLimitSeconds = 5;

        public AddQuestionForm(User user, int questionId) : this(user)
        {
            _questionId = questionId;
        }

        public AddQuestionForm()
        {
            InitializeComponent();

            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

            cmbCorrectAnswer.Items.AddRange(new object[]
            {
                "Answer 1",
                "Answer 2",
                "Answer 3",
                "Answer 4"
            });

            cmbCorrectAnswer.SelectedIndex = -1;
        }

        public AddQuestionForm(User user) : this()
        {
            _currentUser = user;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_currentUser == null ||
                !_currentUser.IsActive ||
                !_currentUser.IsAdmin)
            {
                MessageBox.Show("Administrator access is required.");
                Close();
                return;
            }

            btnSave.Enabled = false;

            try
            {
                List<Category> categories = _categoryRepository.GetAll();

                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = nameof(Category.Name);
                cmbCategory.SelectedIndex = -1;

                btnSave.Enabled = categories.Count > 0;

                if (categories.Count == 0)
                {
                    MessageBox.Show(
                        "Create a category before adding questions.");
                }

                if (_questionId.HasValue)
                {
                    LoadExistingQuestion();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Unable to load categories. Check your database connection.");
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (_currentUser == null ||
                !_currentUser.IsActive ||
                !_currentUser.IsAdmin)
            {
                MessageBox.Show("Administrator access is required.");
                return;
            }

            if (cmbCategory.SelectedItem is not Category category)
            {
                MessageBox.Show("Select a category.");
                return;
            }

            string questionText = txtQuestion.Text.Trim();

            string[] answerTexts =
            {
                txtAnswer1.Text.Trim(),
                txtAnswer2.Text.Trim(),
                txtAnswer3.Text.Trim(),
                txtAnswer4.Text.Trim()
            };

            if (string.IsNullOrWhiteSpace(questionText))
            {
                MessageBox.Show("Enter the question.");
                return;
            }

            if (answerTexts.Any(string.IsNullOrWhiteSpace))
            {
                MessageBox.Show("Enter all four answers.");
                return;
            }

            if (answerTexts.Distinct(StringComparer.OrdinalIgnoreCase).Count() != 4)
            {
                MessageBox.Show("Use four different answers.");
                return;
            }

            if (cmbCorrectAnswer.SelectedIndex < 0)
            {
                MessageBox.Show("Select which answer is correct.");
                return;
            }

            Question question = new Question
            {
                QuestionId = _questionId ?? 0,
                CategoryId = category.CategoryId,
                QuestionText = questionText,
                Points = (int)nudPoints.Value,
                TimeLimitSeconds = _timeLimitSeconds,
                IsActive = _isActive
            };

            for (int i = 0; i < answerTexts.Length; i++)
            {
                question.Answers.Add(new Answer
                {
                    AnswerText = answerTexts[i],
                    IsCorrect = i == cmbCorrectAnswer.SelectedIndex
                });
            }

            btnSave.Enabled = false;

            try
            {
                if (_questionId.HasValue)
                {
                    _questionRepository.UpdateQuestion(
                        question,
                        _currentUser.UserId);
                }
                else
                {
                    _questionRepository.AddQuestion(
                        question,
                        _currentUser.UserId);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                btnSave.Enabled = true;
                return;
            }
            catch (MySqlException ex)
            {
                string message = "The question could not be saved.";

#if DEBUG
                message += $"\nMySQL error {ex.Number}: {ex.Message}";
#endif

                MessageBox.Show(message);
                btnSave.Enabled = true;
                return;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                btnSave.Enabled = true;
                return;
            }

            MessageBox.Show("Question saved.");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void LoadExistingQuestion()
        {
            Question? question =
                _questionRepository.GetById(_questionId!.Value);

            if (question == null)
            {
                MessageBox.Show("This question no longer exists.");
                Close();
                return;
            }

            if (question.Answers.Count != 4 ||
                question.Answers.Count(answer => answer.IsCorrect) != 1)
            {
                MessageBox.Show(
                    "This editor currently requires four answers and one correct answer.");
                Close();
                return;
            }

            Text = "Quizmester - Edit question";
            btnSave.Text = "Save changes";

            txtQuestion.Text = question.QuestionText;

            nudPoints.Minimum = Math.Min(nudPoints.Minimum, question.Points);
            nudPoints.Maximum = Math.Max(nudPoints.Maximum, question.Points);
            nudPoints.Value = question.Points;

            _isActive = question.IsActive;
            _timeLimitSeconds = question.TimeLimitSeconds;

            foreach (Category category in cmbCategory.Items)
            {
                if (category.CategoryId == question.CategoryId)
                {
                    cmbCategory.SelectedItem = category;
                    break;
                }
            }

            TextBox[] answerBoxes =
            {
        txtAnswer1,
        txtAnswer2,
        txtAnswer3,
        txtAnswer4
    };

            for (int i = 0; i < answerBoxes.Length; i++)
            {
                answerBoxes[i].Text = question.Answers[i].AnswerText;

                if (question.Answers[i].IsCorrect)
                {
                    cmbCorrectAnswer.SelectedIndex = i;
                }
            }
        }
    }
}