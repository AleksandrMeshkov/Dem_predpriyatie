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
using Dem_predpriyatie.Service.Helper;

namespace Dem_predpriyatie.Pages_list
{
    /// <summary>
    /// Логика взаимодействия для Staff_pages.xaml
    /// </summary>
    public partial class Staff_pages : Page
    {
        public Staff_pages()
        {
            InitializeComponent();
            InitializeEmployees();
        }

        private void InitializeEmployees()
        {
            var context = Helper.GetContext();
            Staff_list.ItemsSource = context.Employees.Include("Position").Include("Departments").ToList();
        }
    }
}
