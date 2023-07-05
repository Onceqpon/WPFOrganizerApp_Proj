using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public AddNote()
        {
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

        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
