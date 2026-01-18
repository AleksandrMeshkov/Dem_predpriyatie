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
using Dem_predpriyatie.Product_settings;

namespace Dem_predpriyatie.Pages_list
{
    /// <summary>
    /// Логика взаимодействия для Product_pages.xaml
    /// </summary>
    public partial class Product_pages : Page
    {
        private predEnt context = new predEnt();
        public Product_pages()
        {
            InitializeComponent();
            loadProduct();
        }

        private void loadProduct()
        {
            var product = context.Products
                .Include("Specification")           
                .Include("Specification.Recipe")   
                .Include("Specification.Recipe.Materials")
                .ToList();
            Product_list.ItemsSource = product;
        }

        private void Add_btn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Product_add());
        }

        private void Set_btn(object sender, RoutedEventArgs e)
        {
            if (Product_list.SelectedItem == null)
            {
                MessageBox.Show("Выберите продукт");
                return;
            }
            else 
            {
                var selected_product_del = (Products)Product_list.SelectedItem;
                NavigationService.Navigate(new Product_set(selected_product_del));
            }
        }

        private void Del_btn(object sender, RoutedEventArgs e)
        {
            if (Product_list.SelectedItem == null) 
            {
                MessageBox.Show("Выберите продукт");
            }
            else
            {
                var selected_product = (Products)Product_list.SelectedItem;
                context.Products.Remove(selected_product);
                context.SaveChanges();
                MessageBox.Show("Продукт удален");
                loadProduct();
            }
        }
    }
}
