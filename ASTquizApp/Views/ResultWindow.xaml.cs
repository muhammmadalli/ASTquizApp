using ASTquizApp.Models;
using System.Windows;
using ASTquizApp.Services;


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
            ResultText.Text =
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
    }
}