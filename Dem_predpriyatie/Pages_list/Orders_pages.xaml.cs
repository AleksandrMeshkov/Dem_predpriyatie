using Dem_predpriyatie.Service.Helper;
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
using Dem_predpriyatie.Order_settings;

namespace Dem_predpriyatie.Pages_list
{
    /// <summary>
    /// Логика взаимодействия для Orders_pages.xaml
    /// </summary>
    public partial class Orders_pages : Page
    {
        public Orders_pages()
        {
            InitializeComponent();
            InitializeOrders();
        }

        private void InitializeOrders()
        {
            var context = Helper.GetContext();
            Orders_list.ItemsSource = context.Orders.Include("Clients").Include("Status").Include("Specification.Products").Include("Specification.Recipe.Materials").ToList();
        }

        private void Add_btn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Order_add());
        }
    }
}
