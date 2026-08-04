using ASTquizApp.Data;
using System.Windows;
using System.Windows.Controls;

namespace ASTquizApp.Views
{
    public partial class PasswordWindow : Window
    {
        public bool IsAuthenticated { get; private set; }
        public int QuestionCount { get; private set; } = 100;

        public PasswordWindow()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {

            // Password not yet verified
            if (!QuestionCountTextBox.IsEnabled)
            {

                if (PasswordBox.Password == AppSettings.AdminPassword)
                {
                IsAuthenticated = true;
          // added at the end      DialogResult = true;
                QuestionCountTextBox.IsEnabled = true;
                QuestionCountTextBox.Text = "100";
                QuestionCountTextBox.Focus();
                QuestionCountTextBox.SelectAll();
                }

                else
                {
                MessageBox.Show(
                    "Incorrect administrator password.",
                    "Access Denied",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                PasswordBox.Clear();
                PasswordBox.Focus();
                }
            
                return;

            }


            // Validate number of questions
            if (!int.TryParse(QuestionCountTextBox.Text, out int count))
            {
                MessageBox.Show(
                    "Please enter a valid integer.",
                    "Invalid Input",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            if (count < 1 || count > 100)
            {
                MessageBox.Show(
                    "Please enter a number between 1 and 100.",
                    "Invalid Input",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            QuestionCount = count;

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}