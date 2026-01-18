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

namespace Dem_predpriyatie.Material_settings
{
    /// <summary>
    /// Логика взаимодействия для Material_add.xaml
    /// </summary>
    public partial class Material_add : Page
    {
        private predEnt context = new predEnt();
        public Material_add()
        {
            InitializeComponent();
            LoadMeasure();
        }

        private void LoadMeasure()
        {
            cmbMeasurement.ItemsSource = context.Measurement.ToList();
        }
        

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var material = new Materials
            {
                Name = txtName.Text,
                Measurement_id = (int)cmbMeasurement.SelectedValue,
                Quantity = int.Parse(txtQuantity.Text)
            };

            context.Materials.Add(material);
            context.SaveChanges();
            NavigationService.Navigate(new Material_pages());
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtQuantity.Clear();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Material_pages());
        }
    }
}
