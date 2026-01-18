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

        private void MaterialsBtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Material_pages());
        }

        private void ProductBtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Product_pages());
        }

        private void PostBtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Post_materials());
        }
    }
}
