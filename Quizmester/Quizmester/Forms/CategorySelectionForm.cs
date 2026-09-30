using MySql.Data.MySqlClient;
using Quizmester.Data;
using Quizmester.Models;

namespace Quizmester.Forms
{
    public partial class CategorySelectionForm : Form
    {
        private readonly CategoryRepository _categoryRepository =
            new CategoryRepository();

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
            if (chkGeneral.Checked)
            {
                MessageBox.Show("You selected General: all categories.");
                return;
            }

            List<Category> selectedCategories = clbCategories.CheckedItems
                .Cast<Category>()
                .ToList();

            if (selectedCategories.Count == 0)
            {
                MessageBox.Show("Select at least one category or choose General.");
                return;
            }

            // Temporary confirmation until we connect the quiz screen.
            string names = string.Join(
                ", ",
                selectedCategories.Select(category => category.Name));

            MessageBox.Show($"Selected categories: {names}");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}