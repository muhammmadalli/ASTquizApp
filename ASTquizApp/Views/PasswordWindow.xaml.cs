using ASTquizApp.Data;
using System.Windows;
using System.Windows.Controls;

namespace ASTquizApp.Views
{
    public partial class PasswordWindow : Window
    {
        public bool IsAuthenticated { get; private set; }

        public PasswordWindow()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password == AppSettings.AdminPassword)
            {
                IsAuthenticated = true;
                DialogResult = true;
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
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}