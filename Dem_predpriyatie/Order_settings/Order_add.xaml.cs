using Dem_predpriyatie.Service.Helper;
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

namespace Dem_predpriyatie.Order_settings
{
    /// <summary>
    /// Логика взаимодействия для Order_add.xaml
    /// </summary>
    public partial class Order_add : Page
    {
        public Order_add()
        {
            InitializeComponent();
            InitializeClients();
            InitializeProducts();
        }

        private void InitializeClients()
        {
            var context = Helper.GetContext();
            ClientsBox.ItemsSource = context.Clients.ToList();
        }

        private void InitializeProducts()
        {
            var context = Helper.GetContext();
            ProductsBox.ItemsSource = context.Products.ToList();
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ProductsCount.Text != null || ClientsBox.SelectedIndex != -1 || ProductsBox.SelectedIndex != -1 || StartDateOrder.SelectedDate != null || EndDateOrder.SelectedDate != null)
                {
                    var context = Helper.GetContext();
                    Orders order = new Orders();
                    order.Quantity_product = Convert.ToInt32(ProductsCount.Text);
                    var product = ProductsBox.SelectedItem as Products;
                    order.Summ_order = product.Price * Convert.ToInt32(ProductsCount.Text);
                    order.Specification_id = product.Product_id;
                    order.Status_id = 1;
                    var client = ClientsBox.SelectedItem as Clients;
                    order.Client_id = client.Client_id;
                    if (ProductsBox.SelectedIndex + 1 == 1 || ProductsBox.SelectedIndex + 1 == 4 || ProductsBox.SelectedIndex + 1 == 6 || ProductsBox.SelectedIndex + 1 == 3)
                    {
                        order.Department_id = 1;
                    }
                    else if (ProductsBox.SelectedIndex + 1 == 2)
                    {
                        order.Department_id = 13;
                    }
                    else if (ProductsBox.SelectedIndex + 1 == 5)
                    {
                        order.Department_id = 6;
                    }
                    var timeStart = StartDateOrder.SelectedDate;
                    DateTime datetimeStart = timeStart.Value.Date.Add(DateTime.Now.TimeOfDay);
                    order.Date_start = datetimeStart.ToUniversalTime();
                    var timeEnd = StartDateOrder.SelectedDate;
                    DateTime datetimeEnd = timeEnd.Value.Date.Add(DateTime.Now.TimeOfDay);
                    order.Date_end = datetimeStart.ToUniversalTime();
                    if (order.Date_start > order.Date_end)
                    {
                        MessageBox.Show("Вы не можете указать такой промежуток!");
                        StartDateOrder.SelectedDate = null;
                        EndDateOrder.SelectedDate = null;
                        return;
                    }
                    context.Orders.Add(order);
                    context.SaveChanges();
                    MessageBox.Show("Успешно!");
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientsBox.SelectedIndex = -1;
            ProductsBox.SelectedIndex -= 1;
            ProductsCount.Text = "";
            StartDateOrder.SelectedDate = null;
            EndDateOrder.SelectedDate = null;
        }

        private void CancelOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
