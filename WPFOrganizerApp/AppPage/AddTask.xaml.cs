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
using System.Windows.Shapes;
using WPFOrganizerApp.Models;

namespace WPFOrganizerApp.AppPage
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        public int logInUserId {  get; set; }
        public string TaskPriority = "Niski";
        public AddTask(int userID)
        {
            logInUserId = userID;
            InitializeComponent();
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            string taskTitle = TaskTitle.Text;
            string taskDes = TaskDescription.Text;
            

            using (var context = new OrganizerDbContext())
            {
                if (CanCreateTask(taskTitle, taskDes))
                {
                    MessageBox.Show("Zadanie dodana poprawnie");

                    var newTask = new Tasks
                    {
                        UserId = logInUserId,
                        Title = taskTitle,
                        Description = taskDes,
                        Priority = TaskPriority,
                        IsCompleted = false
                    };

                    context.Add(newTask);
                    context.SaveChanges();
                    Close();
                }
            }
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public bool CanCreateTask(string title, string description)
        {
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(TaskPriority))
            {
                return true;
            }
            MessageBox.Show("Uzupełnij wszystkie dane");
            return false;
        }

    }
}
