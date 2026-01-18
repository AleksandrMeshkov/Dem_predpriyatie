using Dem_predpriyatie.Service.Models;
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
using Dem_predpriyatie.Pages_list;

namespace Dem_predpriyatie.Product_settings
{
    /// <summary>
    /// Логика взаимодействия для Product_add.xaml
    /// </summary>
    public partial class Product_add : Page
    {
        private predEnt context = new predEnt();
        public Product_add()
        {
            InitializeComponent();
        }

        private void Btn_clear_click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_close_click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_add_click(object sender, RoutedEventArgs e)
        {
            var product = new Products
            {
                Name = txtName.Text,
                Article = txtArticle.Text,
                Description = txtDescription.Text,
                Price = decimal.Parse(txtPrice.Text)
            };

            context.Products.Add(product);
            context.SaveChanges();
            MessageBox.Show("Продукт добавлен");
            NavigationService.Navigate(new Product_pages());
        }
    }
}
