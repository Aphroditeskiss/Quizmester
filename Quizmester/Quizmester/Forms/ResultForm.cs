using Quizmester.Models;

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
            string rankingMessage,
            int lpGained,
            Rank? oldRank,
            Rank? newRank,
            bool promoted) : this()
        {
            lblReason.Text = reason;

            // Instead of showing the raw quiz score,
            // show how much LP the player gained.
            lblFinalScore.Text = $"+{lpGained} LP";

            lblCorrectAnswers.Text =
                $"Correct answers: {correctAnswers} / {answeredQuestions} answered";

            if (answeredQuestions == 0)
            {
                lblAccuracy.Text =
                    "Accuracy: — (no answers submitted)";
            }
            else
            {
                double accuracy =
                    (double)correctAnswers /
                    answeredQuestions *
                    100;

                lblAccuracy.Text =
                    $"Accuracy: {accuracy:0.#}%";
            }

            // Show rank information.
            if (newRank != null)
            {
                if (promoted && oldRank != null)
                {
                    lblRanking.Text =
                        $"PROMOTED!\n" +
                        $"{oldRank.Name} → {newRank.Name}\n" +
                        $"{newRank.LPIntoRank} LP";
                }
                else
                {
                    lblRanking.Text =
                        $"{newRank.Name}\n" +
                        $"{newRank.LPIntoRank} LP";
                }
            }
            else
            {
                // Fallback in case rank information could not be loaded.
                lblRanking.Text = rankingMessage;
            }
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