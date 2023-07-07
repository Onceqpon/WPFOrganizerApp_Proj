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
    /// Interaction logic for TodoPage.xaml
    /// </summary>
    public partial class TodoPage : Page
    {
        OrganizerDbContext noteData = new OrganizerDbContext();
        int loginUser;

        public TodoPage(int userID)
        {
            loginUser = userID;
            InitializeComponent();
            
            var query =
            from userTask in noteData.Tasks
            where userTask.UserId == loginUser
            select new { userTask.Title, userTask.Description, userTask.Priority, userTask.IsCompleted};

            taskGrid.ItemsSource = query.ToList();

        }

        public void Add_Click(object sender, RoutedEventArgs e)
        {
            AddTask newTask = new AddTask(loginUser);
            newTask.Show();

        }

        public void Del_Click(object sender, RoutedEventArgs e)
        {
            DelTask delTask = new DelTask(loginUser);
            delTask.Show();
        }

        public void Upd_Click(object sender, RoutedEventArgs e)
        {
            UpdateTask updateTask = new UpdateTask(loginUser);
            updateTask.Show();
        }

    }
}
