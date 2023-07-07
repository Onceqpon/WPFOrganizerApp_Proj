using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Win32;
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
    /// Interaction logic for AddNote.xaml
    /// </summary>
    public partial class AddNote : Window
    {

        public ObservableCollection<Category> AllCategories { get; set; }
        public int SelectedCategoryId { get; set; }
        public int loginUserId { get; set; }

        public AddNote(int userId)
        {
            loginUserId = userId;
            InitializeComponent();
            AllCategories = new ObservableCollection<Category>();

            using (var context = new OrganizerDbContext())
            {
                // Pobierz wszystkie kategorie z bazy danych
                AllCategories = new ObservableCollection<Category>(context.Categories.ToList());
            }

            DataContext = this;
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            string noteTitle = NoteTitle.Text;
            string noteContent = NoteContent.Text;
            int noteCategory = SelectedCategoryId;

            using (var context = new OrganizerDbContext())
            {
                if (CanCreateNote(noteTitle, noteContent))
                {
                    MessageBox.Show("Notatka dodana poprawnie");
                    
                    var newNote = new Note
                    {
                        UserId = loginUserId,
                        CategoryId = SelectedCategoryId,
                        Title = noteTitle,
                        Content = noteContent
                    };

                    context.Add(newNote);
                    context.SaveChanges();
                    Close();
                }
            }

        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public bool CanCreateNote(string title, string context)
        {
            if(!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(context) && SelectedCategoryId != 0)
            {
                return true;
            }
            return false;
        }
    }
}
