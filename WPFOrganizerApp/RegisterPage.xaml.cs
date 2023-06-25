using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFOrganizerApp.UserManagment;

namespace WPFOrganizerApp
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string userUsername = txtUsername.Text;
            string userEmail = txtEmail.Text;
            string userPassword = txtPassword.Password;

            var register = new UserManagement();
            if (CanCreate(userUsername, userEmail, userPassword))
            {
                if (register.IsAccountExist(userEmail))
                    MessageBox.Show("Istnieje konto o podanym emailu.");
                else
                {
                    register.registerAccount(userUsername, userEmail, userPassword);
                    MessageBox.Show("Konto utworzone poprawnie. Teraz możesz się zalogować.");
                    LoginPage logiPage = new LoginPage();
                    logiPage.Show();
                    Close();
                }
            }

        }

        private static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, pattern);
        }

        private static bool CanCreate(string name, string email, string password)
        {
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Nie podano nazwy użytkownika");
                return false;
            }
            else if (!IsValidEmail(email))
            {
                MessageBox.Show("Adres Email jest nie poprawny");
                return false;
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Nie wpisano hasła");
                return false;
            }

            return true;

        }
    }
}
