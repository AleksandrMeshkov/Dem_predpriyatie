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

namespace Dem_predpriyatie
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MaterialsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Material_pages());
        }

        private void ProductBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Product_pages());
        }

        private void PostBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Post_materials());
        }

        private void StaffBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Staff_pages());
        }

        private void EquipmentBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Equipment_pages());
        }

        private void OrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Orders_pages());
        }
    }
}
