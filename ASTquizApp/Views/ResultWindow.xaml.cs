using ASTquizApp.Data;
using ASTquizApp.Models;
using ASTquizApp.Services;
using System.Windows;


namespace ASTquizApp.Views
{

    public partial class ResultWindow : Window
    {

        private Result result;

        public ResultWindow(Result result)
        {
            InitializeComponent();
            this.result = result;
            ShowResult();
        }

        private void ShowResult()
        {
            CandidateText.Text =
            "Candidate: "
            + result.CandidateName
            + "\n\nTotal Questions: "
            + result.TotalQuestions
            + "\n\nCorrect Answers: "
            + result.CorrectAnswers
            + "\n\nWrong Answers: "
            + result.WrongAnswers
            + "\n\nPercentage: "
            + result.Percentage.ToString("0.00")
            + "%";
        }

        private void GeneratePdfButton_Click(
        object sender,
        RoutedEventArgs e)
        {
            PdfService pdfService =
                new PdfService();

            pdfService.CreateResultPdf(result);

            MessageBox.Show(
                "PDF Created Successfully");
        }

        private void BackButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            QuizData.Questions.Clear();
            QuizData.Answers.Clear();
            QuizData.CandidateName = "";
            QuizSetupWindow setup =
                new QuizSetupWindow();

            setup.Show();

            this.Close();
        }
    }
}