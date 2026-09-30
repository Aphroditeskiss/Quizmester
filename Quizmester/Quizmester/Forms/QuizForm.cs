using System.Diagnostics;
using MySql.Data.MySqlClient;
using Quizmester.Data;
using Quizmester.Models;

namespace Quizmester.Forms
{
    public partial class QuizForm : Form
    {
        private const int QuizDurationSeconds = 60;

        private readonly List<Question> _questions = new List<Question>();
        private readonly Button[] _answerButtons;
        private readonly User? _currentUser;

        private readonly GameSessionRepository _gameSessionRepository =
            new GameSessionRepository();

        private readonly Stopwatch _clock = new Stopwatch();

        private readonly System.Windows.Forms.Timer _timer =
            new System.Windows.Forms.Timer();

        private int _questionIndex;
        private int _score;
        private double _questionDeadline;
        private bool _skipUsed;
        private bool _finished;

        public QuizForm()
        {
            InitializeComponent();

            _answerButtons = new[]
            {
                btnAnswer1,
                btnAnswer2,
                btnAnswer3,
                btnAnswer4
            };

            foreach (Button button in _answerButtons)
            {
                button.Click += AnswerButton_Click;
            }

            btnSkip.Click += SkipButton_Click;

            _timer.Interval = 100;
            _timer.Tick += Timer_Tick;
        }

        public QuizForm(List<Question> questions, User user) : this()
        {
            _questions.AddRange(questions);
            _currentUser = user;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_currentUser == null)
            {
                MessageBox.Show("Please log in before starting a quiz.");
                Close();
                return;
            }

            if (_questions.Count == 0)
            {
                MessageBox.Show("There are no questions to play.");
                Close();
                return;
            }

            _clock.Start();
            ShowQuestion();

            if (!_finished)
            {
                _timer.Start();
            }
        }

        private void ShowQuestion()
        {
            if (_questionIndex >= _questions.Count)
            {
                FinishQuiz("You finished all available questions.");
                return;
            }

            Question question = _questions[_questionIndex];

            lblQuestion.Text = question.QuestionText;
            lblScore.Text = $"Score: {_score}";

            Answer[] answers = question.Answers.ToArray();
            Random.Shared.Shuffle(answers);

            for (int i = 0; i < _answerButtons.Length; i++)
            {
                _answerButtons[i].Text = answers[i].AnswerText;
                _answerButtons[i].Tag = answers[i];
            }

            // Reset the question deadline without resetting the quiz clock.
            _questionDeadline =
                _clock.Elapsed.TotalSeconds + question.TimeLimitSeconds;

            UpdateTimerLabels();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (CheckTimeLimits())
            {
                UpdateTimerLabels();
            }
        }

        private bool CheckTimeLimits()
        {
            if (_finished)
            {
                return false;
            }

            double elapsed = _clock.Elapsed.TotalSeconds;

            if (elapsed >= QuizDurationSeconds)
            {
                FinishQuiz("Time is up!");
                return false;
            }

            if (elapsed >= _questionDeadline)
            {
                _questionIndex++;
                ShowQuestion();
                return false;
            }

            return true;
        }

        private void UpdateTimerLabels()
        {
            double elapsed = _clock.Elapsed.TotalSeconds;

            int quizSeconds = (int)Math.Ceiling(
                Math.Max(0, QuizDurationSeconds - elapsed));

            int questionSeconds = (int)Math.Ceiling(
                Math.Max(
                    0,
                    Math.Min(_questionDeadline, QuizDurationSeconds) - elapsed));

            lblQuizTime.Text = $"Quiz: {quizSeconds}s";
            lblQuestionTime.Text = $"Question: {questionSeconds}s";

            lblQuizTime.ForeColor =
                quizSeconds <= 10 ? Color.Red : SystemColors.ControlText;
        }

        private void AnswerButton_Click(object? sender, EventArgs e)
        {
            // Reject late answers even if the next timer tick has not run yet.
            if (!CheckTimeLimits())
            {
                return;
            }

            if (sender is not Button button ||
                button.Tag is not Answer answer)
            {
                return;
            }

            Question question = _questions[_questionIndex];

            if (answer.IsCorrect)
            {
                _score += question.Points;
            }

            _questionIndex++;
            ShowQuestion();
        }

        private void SkipButton_Click(object? sender, EventArgs e)
        {
            if (!CheckTimeLimits() || _skipUsed)
            {
                return;
            }

            _skipUsed = true;
            btnSkip.Enabled = false;
            btnSkip.Text = "Skip used";

            _questionIndex++;
            ShowQuestion();
        }

        private void FinishQuiz(string reason)
        {
            if (_finished)
            {
                return;
            }

            _finished = true;
            _timer.Stop();
            _clock.Stop();

            foreach (Button button in _answerButtons)
            {
                button.Enabled = false;
            }

            btnSkip.Enabled = false;
            lblScore.Text = $"Score: {_score}";
            UpdateTimerLabels();

            string saveMessage;

            if (_currentUser == null)
            {
                saveMessage = "Score was not saved: no player is logged in.";
            }
            else
            {
                GameSession game = new GameSession
                {
                    UserId = _currentUser.UserId,
                    Score = _score
                };

                try
                {
                    game.GameSessionId = _gameSessionRepository.Save(game);
                    saveMessage = "Your score has been saved.";
                }
                catch (MySqlException ex)
                {
                    saveMessage = "Your score could not be saved.";

#if DEBUG
                    saveMessage +=
                        $"\nMySQL error {ex.Number}: {ex.Message}";
#endif
                }

                if (game.GameSessionId > 0)
                {
                    saveMessage += "\n" + GetRankingMessage(game.GameSessionId);
                }
            }

            MessageBox.Show(
                $"{reason}\nFinal score: {_score}\n\n{saveMessage}",
                "Quiz finished",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Close();
        }

        private string GetRankingMessage(int gameSessionId)
        {
            try
            {
                List<ScoreboardEntry> topTen =
                    _gameSessionRepository.GetTopTen();

                ScoreboardEntry? entry = topTen.FirstOrDefault(
                    score => score.GameSessionId == gameSessionId);

                if (entry == null)
                {
                    return "This game did not reach the top 10.";
                }

                return $"You reached position {entry.Position} in the top 10!";
            }
            catch (MySqlException)
            {
                return "Your ranking could not be loaded.";
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _finished = true;
            _timer.Stop();
            _timer.Dispose();
            _clock.Stop();

            base.OnFormClosed(e);
        }
    }
}