using MySql.Data.MySqlClient;
using Quizmester.Data;
using Quizmester.Models;

namespace Quizmester.Forms
{
    public partial class CategorySelectionForm : Form
    {
        private readonly CategoryRepository _categoryRepository =
            new CategoryRepository();

        private readonly QuestionRepository _questionRepository =
            new QuestionRepository();

        private readonly User? _currentUser;

        public CategorySelectionForm()
        {
            InitializeComponent();
        }

        public CategorySelectionForm(User user) : this()
        {
            _currentUser = user;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            clbCategories.Enabled = !chkGeneral.Checked;
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                List<Category> categories = _categoryRepository.GetAll();

                clbCategories.Items.Clear();

                foreach (Category category in categories)
                {
                    clbCategories.Items.Add(category);
                }

                btnContinue.Enabled = categories.Count > 0;

                if (categories.Count == 0)
                {
                    MessageBox.Show("No categories are available yet.");
                }
            }
            catch (MySqlException)
            {
                btnContinue.Enabled = false;

                MessageBox.Show(
                    "Unable to load categories. Check your database connection.",
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void chkGeneral_CheckedChanged(object sender, EventArgs e)
        {
            clbCategories.Enabled = !chkGeneral.Checked;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Please log in before starting a quiz.");
                return;
            }

            // null tells the repository to load all categories.
            List<int>? categoryIds = null;

            if (!chkGeneral.Checked)
            {
                categoryIds = clbCategories.CheckedItems
                    .Cast<Category>()
                    .Select(category => category.CategoryId)
                    .ToList();

                if (categoryIds.Count == 0)
                {
                    MessageBox.Show(
                        "Select at least one category or choose General.");
                    return;
                }
            }

            List<Question> questions;

            try
            {
                questions = _questionRepository.GetQuestions(categoryIds);
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Unable to load questions. Check your database connection " +
                    "and table structure.",
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (questions.Count == 0)
            {
                MessageBox.Show(
                    "No active questions were found for this selection.");
                return;
            }

            foreach (Question question in questions)
            {
                if (question.Answers.Count != 4 ||
                    question.Answers.Count(answer => answer.IsCorrect) != 1)
                {
                    MessageBox.Show(
                        $"Question {question.QuestionId} must have four answers " +
                        "and exactly one correct answer.",
                        "Incomplete question",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            DialogResult result;

            do
            {
                using QuizForm quizForm = new QuizForm(questions, _currentUser);
                result = quizForm.ShowDialog(this);
            }
            while (result == DialogResult.Retry);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}