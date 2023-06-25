using WPFOrganizerApp.UserManagment;
using System.Windows;
using WPFOrganizerApp.Models;


namespace WPFOrganizerApp
{

    public partial class LoginPage : Window
    {
        
        public LoginPage()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string userEmail = txtEmail.Text;
            string userPassword = txtPassword.Password;

            var ob = new UserManagement();

            if (ob.IsAccountExist(userEmail, userPassword))
            {
                MessageBox.Show("Zalogowano poprawnie.");
                MainWindow aplication = new MainWindow(ob.GetUserParameters(userEmail,userPassword));
                aplication.Show();
                Close();
            }
            else
                MessageBox.Show("Nie zalogowano");

        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            registerPage.Show();
            Close();
        }
    }
}
