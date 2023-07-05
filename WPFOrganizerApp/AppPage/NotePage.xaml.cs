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
using WPFOrganizerApp.Models;

namespace WPFOrganizerApp.AppPage
{
    /// <summary>
    /// Interaction logic for NotePage.xaml
    /// </summary>
    public partial class NotePage : Page
    {
        OrganizerDbContext noteData = new OrganizerDbContext();
        int loginUser;

        public NotePage(int userID)
        {  
            loginUser = userID;
            InitializeComponent();
            var query =
            from userNote in noteData.Notes
            where userNote.UserId == loginUser
            select new { userNote.Title, userNote.Content };

            noteGrid.ItemsSource = query.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var query =
            from userNote in noteData.Notes
            where userNote.UserId == loginUser
            select new { userNote.Title, userNote.Content };

            noteGrid.ItemsSource = query.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddNote addNote = new AddNote();
            addNote.Show();
        }


    }
}
