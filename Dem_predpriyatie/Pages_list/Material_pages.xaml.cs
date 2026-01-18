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
using Dem_predpriyatie.Service.Models;
using Dem_predpriyatie.Material_settings;
using System.Windows.Media.Media3D;

namespace Dem_predpriyatie.Pages_list
{
    /// <summary>
    /// Логика взаимодействия для Material_pages.xaml
    /// </summary>
    public partial class Material_pages : Page
    {
        private predEnt context = new predEnt();
        public Material_pages()
        {
            InitializeComponent();
            ProductView();
        }

        private void ProductView()
        {
            var materials = context.Materials
                .Include("Measurement")
                .ToList();
            Material_list.ItemsSource = materials;
        }

        private void Add_btn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Material_add());
        }

        private void Set_btn(object sender, RoutedEventArgs e)
        {
            if (Material_list.SelectedItem == null)
            {
                MessageBox.Show("Выберите материал для редактирования");
                return;
            }

            var selectedMaterial = (Materials)Material_list.SelectedItem;
            NavigationService.Navigate(new Material_sett(selectedMaterial));
        }

        private void Del_btn(object sender, RoutedEventArgs e)
        {
            if (Material_list.SelectedItem == null)
            {
                MessageBox.Show("Выберите материал для удаления");
            }
            else 
            {
                var selected_material = (Materials)Material_list.SelectedItem;
                context.Materials.Remove(selected_material);
                context.SaveChanges();
                MessageBox.Show("Материал удален");
                ProductView();

            }
        }
    }
}
