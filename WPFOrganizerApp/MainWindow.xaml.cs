using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WPFOrganizerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow(string logInName)
        {
            InitializeComponent();
            userAccount.Text = "Zalogowano jako: " + logInName;
        }

        private void noteClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new NotePage();
        }

        private void todoClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new TodoPage();
        }

        private void logoutClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wylogowano poprawnie");
            LoginPage logiPage = new LoginPage();
            logiPage.Show();
            Close();
        }
    }
}
