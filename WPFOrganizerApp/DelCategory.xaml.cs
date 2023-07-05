using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

namespace WPFOrganizerApp
{
    /// <summary>
    /// Interaction logic for DelCategory.xaml
    /// </summary>
    public partial class DelCategory : Window
    {

        public ObservableCollection<Category> UnusedCategories { get; set; }
        public int SelectedCategoryId { get; set; }
        public DelCategory()
        {
            SelectedCategoryId = 0;
            InitializeComponent();

            using (var context = new OrganizerDbContext())
            {

                UnusedCategories = new ObservableCollection<Category>();

                var usedCategoryIds = context.Notes
                .Where(note => note.Category != null)
                .Select(note => note.CategoryId)
                .Distinct()
                .ToList();

                var unusedCategories = context.Categories
                    .Where(category => !usedCategoryIds.Contains(category.Id))
                    .ToList();

                foreach (var category in unusedCategories)
                {
                    UnusedCategories.Add(category);
                }
            }

            DataContext = this;
        
        }

        public void Del_Click(object sender, RoutedEventArgs e)
        {
            using( var context = new OrganizerDbContext())
            {
                if (SelectedCategoryId != 0)
                {
                    Category delCategory = new Category() { Id = SelectedCategoryId };
                    context.Categories.Attach(delCategory);
                    context.Categories.Remove(delCategory);
                    context.SaveChanges();
                    MessageBox.Show("Kategoria usunięta poprawnie");
                    Close();
                }
                else
                    MessageBox.Show("Nie wybrałeś kategori do usunięcia");
            }

        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
