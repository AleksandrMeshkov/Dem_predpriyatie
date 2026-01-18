using Dem_predpriyatie.Pages_list;
using Dem_predpriyatie.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Dem_predpriyatie.Material_settings
{
    /// <summary>
    /// Логика взаимодействия для Material_sett.xaml
    /// </summary>
    public partial class Material_sett : Page
    {
        private Materials selectedMaterial;
        private predEnt context = new predEnt();
        public Material_sett(Materials material)
        {
            InitializeComponent();
            selectedMaterial = material;
            LoadMaterialData();
        }

        private void LoadMaterialData()
        {
            if (selectedMaterial != null)
            {
                txtName.Text = selectedMaterial.Name;
                txtQuantity.Text = selectedMaterial.Quantity.ToString();

                cmbMeasurement.ItemsSource = context.Measurement.ToList();
                cmbMeasurement.SelectedValue = selectedMaterial.Measurement_id;

            }
        }

        private void Btn_set_click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtQuantity.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            else
            {
                var material = context.Materials
                    .FirstOrDefault(m => m.Material_id == selectedMaterial.Material_id);

                material.Name = txtName.Text;
                material.Quantity = int.Parse(txtQuantity.Text);
                material.Measurement_id = (int)cmbMeasurement.SelectedValue;

                context.SaveChanges();

                NavigationService.Navigate(new Material_pages());
            }
            
            
        }

        private void Btn_clear_click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtQuantity.Clear();    
        }

        private void Btn_close_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Material_pages());
        }
    }
}
