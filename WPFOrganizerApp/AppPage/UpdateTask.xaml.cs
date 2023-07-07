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
    /// Interaction logic for UpdateTask.xaml
    /// </summary>
    public partial class UpdateTask : Window
    {
        public int logInUserId { get; set; }
        public OrganizerDbContext noteData = new OrganizerDbContext();
        public ObservableCollection<Tasks> AllUserTitle { get; set; }
        public int SelectedNoteId { get; set; }
        public UpdateTask(int userId)
        {
            SelectedNoteId = 0;
            logInUserId = userId;
            AllUserTitle = new ObservableCollection<Tasks>();
            InitializeComponent();

            using (var context = new OrganizerDbContext())
            {

                var userTask = context.Tasks
                        .Where(task => task.UserId == logInUserId)
                        .ToList();

                foreach (var task in userTask)
                {
                    AllUserTitle.Add(task);
                }
            }

            DataContext = this;

        }
        public void Complet_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new OrganizerDbContext())
            {
                if (SelectedNoteId != 0)
                {
                    var taskToUpdate = context.Tasks.FirstOrDefault(t => t.Id == SelectedNoteId);
                    if (taskToUpdate != null)
                    {
                        // Zmiana wartości właściwości
                        taskToUpdate.IsCompleted = true;

                        // Zapisanie zmian w bazie danych
                        context.SaveChanges();

                        MessageBox.Show("Zadanie zakończone");
                        Close();
                    }
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
