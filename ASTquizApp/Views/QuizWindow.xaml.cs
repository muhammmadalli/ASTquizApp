using ASTquizApp.Data;
using ASTquizApp.Models;
using ASTquizApp.Services;
using System.Windows;
using System.Windows.Threading;

namespace ASTquizApp.Views
{

    public partial class QuizWindow : Window
    {
        private int currentQuestionIndex = 0;

        private List<Question> questions;
        
        private DispatcherTimer? quizTimer;
        private int remainingSeconds;

        public QuizWindow()
        {
            InitializeComponent();

            remainingSeconds =
                QuizData.TimeAllowedMinutes * 60;

            StartTimer();

            questions = QuizData.Questions;
            DisplayQuestion();
        }

        private void DisplayQuestion()
        {

            if (QuizData.Answers.ContainsKey(currentQuestionIndex))
            {
                string answer =
                    QuizData.Answers[currentQuestionIndex];

                OptionARadio.IsChecked =
                    answer == "A";

                OptionBRadio.IsChecked =
                    answer == "B";

                OptionCRadio.IsChecked =
                    answer == "C";

                OptionDRadio.IsChecked =
                    answer == "D";
            }

            Question question =
                questions[currentQuestionIndex];

            QuestionNumberText.Text =
                "Question "
                + (currentQuestionIndex + 1)
                + " / "
                + questions.Count;

            QuestionText.Text =
                question.QuestionText;

            OptionARadio.Content =
                question.OptionA;

            OptionBRadio.Content =
                question.OptionB;

            OptionCRadio.Content =
                question.OptionC;

            OptionDRadio.Content =
                question.OptionD;

            OptionARadio.IsChecked = false;
            OptionBRadio.IsChecked = false;
            OptionCRadio.IsChecked = false;
            OptionDRadio.IsChecked = false;

            QuestionInfoText.Text =
                "Book: "
                + question.Book
                + "\nChapter: "
                + question.Chapter
                + "\nTopic: "
                + question.Topic;

        }

        private void SaveCurrentAnswer()
        {
            string answer = "";

            if (OptionARadio.IsChecked == true)
                answer = "A";

            else if (OptionBRadio.IsChecked == true)
                answer = "B";

            else if (OptionCRadio.IsChecked == true)
                answer = "C";

            else if (OptionDRadio.IsChecked == true)
                answer = "D";

            QuizData.Answers[currentQuestionIndex]
                = answer;
        }

        private void NextButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            SaveCurrentAnswer();

            currentQuestionIndex++;

            if (currentQuestionIndex >= questions.Count)
            {
                MessageBox.Show(
                    "Quiz Completed");
                SubmitQuiz();
                return;
            }

            DisplayQuestion();
        }

        private void PreviousButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            SaveCurrentAnswer();
            currentQuestionIndex--;
            if (currentQuestionIndex < 0)
            {
                currentQuestionIndex = 0;
                return;
            }
            DisplayQuestion();
        }

        private void FinishButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            SubmitQuiz();
        }

        private void SubmitQuiz()
        {
            if (quizTimer != null)
                quizTimer.Stop();

            SaveCurrentAnswer();

            ResultService resultService =
                new ResultService();

            var result =
                resultService.CalculateResult(
                    QuizData.Questions,
                    QuizData.Answers,
                    QuizData.CandidateName);

            ResultWindow window =
                new ResultWindow(result);

            window.ShowDialog();

            this.Close();
        }

        private void StartTimer()
        {
            quizTimer = new DispatcherTimer();

            quizTimer.Interval =
                TimeSpan.FromSeconds(1);

            quizTimer.Tick += QuizTimer_Tick;

            quizTimer.Start();
        }

        private void QuizTimer_Tick(
            object? sender,
            EventArgs e)
            {
            remainingSeconds--;

            int minutes =
                remainingSeconds / 60;

            int seconds =
                remainingSeconds % 60;


            TimerTextBlock.Text =
                $"Time: {minutes:00}:{seconds:00}";


            if (remainingSeconds <= 0)
            {
                quizTimer?.Stop();

                MessageBox.Show(
                    "Time is over. Quiz will be submitted.",
                    "Time Finished",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                SubmitQuiz();
            }
        }


        protected override void OnClosed(EventArgs e)
        {
            if (quizTimer != null)
            {
                quizTimer.Stop();
            }

            base.OnClosed(e);
        }

    }
}