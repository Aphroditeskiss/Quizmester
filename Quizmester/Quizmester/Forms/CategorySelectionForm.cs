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

        public CategorySelectionForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
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
            List<int>? categoryIds = null;

            if (!chkGeneral.Checked)
            {
                categoryIds = clbCategories.CheckedItems
                    .Cast<Category>()
                    .Select(category => category.CategoryId)
                    .ToList();

                if (categoryIds.Count == 0)
                {
                    MessageBox.Show("Select at least one category or choose General.");
                    return;
                }
            }

            try
            {
                List<Question> questions =
                    _questionRepository.GetQuestions(categoryIds);

                if (questions.Count == 0)
                {
                    MessageBox.Show("No active questions were found for this selection.");
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

                using QuizForm quizForm = new QuizForm(questions);
                quizForm.ShowDialog(this);
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Unable to load questions. Check your database connection " +
                    "and table structure.",
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}