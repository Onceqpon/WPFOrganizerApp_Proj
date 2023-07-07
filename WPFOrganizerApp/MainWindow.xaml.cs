using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFOrganizerApp.AppPage;
using WPFOrganizerApp.Models;

namespace WPFOrganizerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        User logInUser {get;set;}

        private string userEmail;

        public string UserEmail
        {
            get { return userEmail; }
            set
            {
                if (userEmail != value)
                {
                    userEmail = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainWindow(User userValue)
        {
            logInUser = userValue;
            InitializeComponent();
            DataContext = this;
            userAccount.Text = "Zalogowano jako: " + userValue.Name;

            userEmail = userValue.Email;
        }

        private void noteClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new NotePage(logInUser.Id);
        }

        private void todoClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new TodoPage(logInUser.Id);
        }

        private void logoutClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wylogowano poprawnie");
            LoginPage logiPage = new LoginPage();
            logiPage.Show();
            Close();
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryAdd Category = new CategoryAdd();
            Category.Show();
        }

        private void DelCategory_Click(Object sender, RoutedEventArgs e)
        {
            DelCategory Category = new DelCategory();
            Category.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
