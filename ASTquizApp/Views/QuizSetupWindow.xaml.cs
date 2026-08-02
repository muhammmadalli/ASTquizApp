using ASTquizApp.Services;
using ASTquizApp.Data;
using ASTquizApp.Models;
using ASTquizApp.Views; 
using Microsoft.Win32;
using System.Windows;

namespace ASTquizApp.Views
{
    /// <summary>
    /// Interaction logic for QuizSetupWindow.xaml
    /// </summary>
    public partial class QuizSetupWindow : Window
    {
        public List<string> SelectedFiles { get; set; }
            = new List<string>();

        public QuizSetupWindow()
        {
            InitializeComponent();
        }

        private void SelectFilesButton_Click(object sender, RoutedEventArgs e)
        {

            PasswordWindow passwordWindow = new PasswordWindow();

            bool? result1 = passwordWindow.ShowDialog();

            if (result1 != true || !passwordWindow.IsAuthenticated)
                return;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
                "Excel Files (*.xlsx)|*.xlsx";
            dialog.Multiselect = true;
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                SelectedFiles.Clear();
                FilesListBox.Items.Clear();

                foreach (string file in dialog.FileNames)
                {
                    SelectedFiles.Add(file);
                    FilesListBox.Items.Add(file);
                }
            }
        }

        private void StartQuizButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CandidateNameBox.Text))
            {
                MessageBox.Show(
                    "Please enter candidate name");

                return;
            }

            if (SelectedFiles.Count == 0)
            {
                MessageBox.Show(
                    "Please select Excel files first");
                return;
            }

            ExcelService excelService = new ExcelService();

            List<Question> allQuestions =
                excelService.LoadQuestions(SelectedFiles);

            if (allQuestions.Count < 100)
            {
                MessageBox.Show(
                    "Question bank contains less than 100 questions");
                return;
            }

            QuestionService questionService =
                new QuestionService();

            QuizData.Questions =
                questionService.GetRandomQuestions(
                    allQuestions);

            QuizData.CandidateName = CandidateNameBox.Text;

            QuizWindow quizWindow = new QuizWindow();

            quizWindow.Show();

            this.Close();
        }
    }
}
