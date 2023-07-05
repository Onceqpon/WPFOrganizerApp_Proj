using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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

namespace WPFOrganizerApp
{
    /// <summary>
    /// Interaction logic for CategoryAdd.xaml
    /// </summary>
    public partial class CategoryAdd : Window
    {
        public CategoryAdd()
        {

            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            OrganizerDbContext db = new OrganizerDbContext();
            Category addCategory = new Category();
            addCategory.Name = newCategory.Text;
            var checkCategories = db.Categories.FirstOrDefault(x => x.Name == newCategory.Text);
            if (checkCategories == null)
            {
                db.Add(addCategory);
                db.SaveChanges();
                MessageBox.Show("Kategorie utworzono poprawnie");
                Close();

            }
            else
            {
                MessageBox.Show("Ta Kategoria już istnieje");
            }


        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
