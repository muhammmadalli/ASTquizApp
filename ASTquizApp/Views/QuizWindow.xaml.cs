using ASTquizApp.Data;
using ASTquizApp.Models;
using System.Windows;

namespace ASTquizApp.Views
{

    public partial class QuizWindow : Window
    {
        private int currentQuestionIndex = 0;

        private List<Question> questions;

        public QuizWindow()
        {
            InitializeComponent();
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
                Close();
                return;
            }

            DisplayQuestion();
        }
    }
}