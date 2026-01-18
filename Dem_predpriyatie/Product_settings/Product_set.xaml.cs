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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dem_predpriyatie.Pages_list;

namespace Dem_predpriyatie.Product_settings
{
    /// <summary>
    /// Логика взаимодействия для Product_set.xaml
    /// </summary>
    public partial class Product_set : Page
    {
        private Products selected_product_del;
        private predEnt context = new predEnt();
        public Product_set(Products products)
        {
            InitializeComponent();
            selected_product_del = products;
            Load_product_data();

        }

        private void Load_product_data()
        {
            if (selected_product_del != null) 
            {
                txtName.Text = selected_product_del.Name;
                txtArticle.Text = selected_product_del.Article;
                txtDescription.Text = selected_product_del.Description;
                txtPrice.Text = selected_product_del.Price.ToString();
            }
        }

        private void Btn_set_click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtArticle.Text == "" || txtDescription.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            else
            {
                var product = context.Products
                    .FirstOrDefault(p => p.Product_id == selected_product_del.Product_id);

                product.Name = txtName.Text;
                product.Article = txtArticle.Text;
                product.Description = txtDescription.Text;
                product.Price = decimal.Parse(txtPrice.Text);

                context.SaveChanges();
                NavigationService.Navigate(new Product_pages());
            }
        }

        private void Btn_clear_click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtArticle.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
        }

        private void Btn_close_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Product_pages());
        }
    }
}
