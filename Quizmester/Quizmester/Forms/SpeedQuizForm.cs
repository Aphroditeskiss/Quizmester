using System.Diagnostics;
using MySql.Data.MySqlClient;
using Quizmester.Data;
using Quizmester.Models;

namespace Quizmester.Forms
{
    public partial class SpeedQuizForm : Form
    {
        private readonly User _currentUser;

        private readonly List<Question> _questions =
            new List<Question>();

        private readonly Button[] _answerButtons;

        private readonly Stopwatch _clock =
            new Stopwatch();

        private readonly System.Windows.Forms.Timer _timer =
            new System.Windows.Forms.Timer();

        private readonly QuestionRepository _questionRepository =
            new QuestionRepository();

        private readonly SpeedQuizRepository _speedQuizRepository =
            new SpeedQuizRepository();

        private int _questionIndex;
        private int _correctAnswers;
        private int _penaltySeconds;

        private bool _finished;

        public SpeedQuizForm(User user)
        {
            InitializeComponent();

            _currentUser = user;

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

            // Refresh the displayed stopwatch every 50ms.
            _timer.Interval = 50;
            _timer.Tick += Timer_Tick;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                // Load all available quiz questions.
                List<Question> questions =
                    _questionRepository.GetQuestions();

                if (questions.Count == 0)
                {
                    MessageBox.Show(
                        "There are no questions available for the Speed Quiz.");

                    Close();
                    return;
                }

                // Randomise question order.
                Question[] shuffledQuestions =
                    questions.ToArray();

                Random.Shared.Shuffle(shuffledQuestions);

                _questions.AddRange(shuffledQuestions);

                // Set starting labels.
                lblCorrect.Text =
                    "Correct: 0 / 10";

                lblPenalty.Text =
                    "Penalty: +0s";

                lblTimer.Text =
                    "00:00.00";

                // Start the Speed Quiz.
                _clock.Start();
                _timer.Start();

                ShowQuestion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Unable to load questions.\n\n{ex.Message}",
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Close();
            }
        }

        private void ShowQuestion()
        {
            if (_finished)
            {
                return;
            }

            // If we reach the end of the list,
            // shuffle all questions again.
            if (_questionIndex >= _questions.Count)
            {
                Question[] shuffledQuestions =
                    _questions.ToArray();

                Random.Shared.Shuffle(shuffledQuestions);

                _questions.Clear();
                _questions.AddRange(shuffledQuestions);

                _questionIndex = 0;
            }

            Question question =
                _questions[_questionIndex];

            lblQuestion.Text =
                question.QuestionText;

            // Shuffle the four answers.
            Answer[] answers =
                question.Answers.ToArray();

            Random.Shared.Shuffle(answers);

            for (int i = 0;
                 i < _answerButtons.Length;
                 i++)
            {
                _answerButtons[i].Text =
                    answers[i].AnswerText;

                _answerButtons[i].Tag =
                    answers[i];

                _answerButtons[i].Enabled =
                    true;
            }
        }

        private void AnswerButton_Click(
            object? sender,
            EventArgs e)
        {
            if (_finished)
            {
                return;
            }

            if (sender is not Button button ||
                button.Tag is not Answer answer)
            {
                return;
            }

            if (answer.IsCorrect)
            {
                _correctAnswers++;

                lblCorrect.Text =
                    $"Correct: {_correctAnswers} / 10";

                // The quiz ends immediately
                // after 10 correct answers.
                if (_correctAnswers >= 10)
                {
                    FinishSpeedQuiz();
                    return;
                }
            }
            else
            {
                // Wrong answer = 5 second penalty.
                _penaltySeconds += 5;

                lblPenalty.Text =
                    $"Penalty: +{_penaltySeconds}s";
            }

            _questionIndex++;

            ShowQuestion();
        }

        private void Timer_Tick(
            object? sender,
            EventArgs e)
        {
            if (_finished)
            {
                return;
            }

            TimeSpan displayedTime =
                _clock.Elapsed +
                TimeSpan.FromSeconds(_penaltySeconds);

            lblTimer.Text =
                FormatTime(displayedTime);
        }

        private string FormatTime(TimeSpan time)
        {
            return
                $"{(int)time.TotalMinutes:00}:" +
                $"{time.Seconds:00}." +
                $"{time.Milliseconds / 10:00}";
        }

        private void FinishSpeedQuiz()
        {
            if (_finished)
            {
                return;
            }

            _finished = true;

            _clock.Stop();
            _timer.Stop();

            foreach (Button button in _answerButtons)
            {
                button.Enabled = false;
            }

            // Actual elapsed time + accumulated penalties.
            TimeSpan finalTime =
                _clock.Elapsed +
                TimeSpan.FromSeconds(_penaltySeconds);

            int finalTimeMs =
                (int)finalTime.TotalMilliseconds;

            int? previousFastestTime = null;

            try
            {
                // IMPORTANT:
                // Get the old record BEFORE saving this result.
                previousFastestTime =
                    _speedQuizRepository.GetFastestTime();

                bool isNewRecord =
                    previousFastestTime == null ||
                    finalTimeMs < previousFastestTime.Value;

                SpeedQuizResult result =
                    new SpeedQuizResult
                    {
                        UserId =
                            _currentUser.UserId,

                        CompletionTimeMs =
                            finalTimeMs,

                        PlayedAt =
                            DateTime.Now
                    };

                _speedQuizRepository.Save(result);

                string finalTimeText =
                    FormatTime(finalTime);

                string message;

                if (isNewRecord)
                {
                    message =
                        $"NEW FASTEST TIME!\n\n" +
                        $"Your time: {finalTimeText}";

                    if (previousFastestTime != null)
                    {
                        TimeSpan previousTime =
                            TimeSpan.FromMilliseconds(
                                previousFastestTime.Value);

                        message +=
                            $"\n\nPrevious record: " +
                            $"{FormatTime(previousTime)}";
                    }
                }
                else
                {
                    TimeSpan fastestTime =
                        TimeSpan.FromMilliseconds(
                            previousFastestTime!.Value);

                    string? fastestPlayer =
                        _speedQuizRepository.GetFastestPlayer();

                    message =
                        $"Speed Quiz complete!\n\n" +
                        $"Your time: {finalTimeText}\n" +
                        $"Penalty: +{_penaltySeconds}s\n\n" +
                        $"Fastest time: " +
                        $"{FormatTime(fastestTime)}";

                    if (!string.IsNullOrWhiteSpace(fastestPlayer))
                    {
                        message +=
                            $"\nSet by: {fastestPlayer}";
                    }
                }

                MessageBox.Show(
                    message,
                    "Speed Quiz Results",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Your time was {FormatTime(finalTime)}, " +
                    $"but the result could not be saved.\n\n" +
                    $"{ex.Message}",
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            Close();
        }

        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            _finished = true;

            _clock.Stop();

            _timer.Stop();
            _timer.Dispose();

            base.OnFormClosed(e);
        }
    }
}