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
    /// Interaction logic for DelNote.xaml
    /// </summary>
    public partial class DelNote : Window
    {
        public int logInUserId { get; set; }
        public OrganizerDbContext noteData = new OrganizerDbContext();
        public ObservableCollection<Note> AllUserTitle { get; set; }
        public int SelectedNoteId { get; set; }
        public DelNote(int userId)
        {
            SelectedNoteId = 0;
            logInUserId = userId;
            AllUserTitle = new ObservableCollection<Note>();
            InitializeComponent();

            using (var context = new OrganizerDbContext())
            {

                var userNote = context.Notes
                        .Where(note => note.UserId == logInUserId)
                        .ToList();

                foreach (var note in userNote)
                {
                    AllUserTitle.Add(note);
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
                    Note delNote = new Note() { Id = SelectedNoteId };
                    context.Notes.Attach(delNote);
                    context.Notes.Remove(delNote);
                    context.SaveChanges();
                    MessageBox.Show("Notatka usunięta poprawnie");
                    Close();
                }
                else
                    MessageBox.Show("Nie wybrałeś notatki do usunięcia");
            }
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
