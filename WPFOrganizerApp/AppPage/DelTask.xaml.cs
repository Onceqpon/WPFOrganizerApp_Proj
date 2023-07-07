using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using WPFOrganizerApp.Models;

namespace WPFOrganizerApp.AppPage
{
    /// <summary>
    /// Interaction logic for DelTask.xaml
    /// </summary>
    public partial class DelTask : Window
    {
        public int logInUserId { get; set; }
        public ObservableCollection<Tasks> AllUserTitle { get; set; }
        public int SelectedNoteId { get; set; }
        public DelTask(int userId)
        {
            SelectedNoteId = 0;
            logInUserId = userId;
            AllUserTitle = new ObservableCollection<Tasks>();
            InitializeComponent();

            using (var context = new OrganizerDbContext())
            {

                var userTask = context.Tasks
                        .Where(tasks => tasks.UserId == logInUserId)
                        .ToList();

                foreach (var task in userTask)
                {
                    AllUserTitle.Add(task);
                }
            }

            DataContext = this;

        }

        public void Del_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new OrganizerDbContext())
            {
                if (SelectedNoteId != 0)
                {
                    Tasks delTask = new Tasks() { Id = SelectedNoteId };
                    context.Tasks.Attach(delTask);
                    context.Tasks.Remove(delTask);
                    context.SaveChanges();
                    MessageBox.Show("Zadanie usunięte poprawnie");
                    Close();
                }
                else
                    MessageBox.Show("Nie wybrałeś zadania do usunięcia");
            }
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
