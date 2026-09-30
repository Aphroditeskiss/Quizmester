namespace Quizmester.Forms
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();

            btnPlayAgain.Click += btnPlayAgain_Click;
            btnBack.Click += btnBack_Click;
        }

        public ResultForm(
            int score,
            int correctAnswers,
            int answeredQuestions,
            string reason,
            string rankingMessage) : this()
        {
            lblReason.Text = reason;
            lblFinalScore.Text = $"Score: {score}";

            lblCorrectAnswers.Text =
                $"Correct answers: {correctAnswers} / {answeredQuestions} answered";

            if (answeredQuestions == 0)
            {
                lblAccuracy.Text = "Accuracy: — (no answers submitted)";
            }
            else
            {
                double accuracy =
                    (double)correctAnswers / answeredQuestions * 100;

                lblAccuracy.Text = $"Accuracy: {accuracy:0.#}%";
            }

            lblRanking.Text = rankingMessage;
        }

        private void btnPlayAgain_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void btnBack_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}