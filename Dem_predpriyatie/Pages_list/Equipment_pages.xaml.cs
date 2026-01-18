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
    /// Логика взаимодействия для Equipment_pages.xaml
    /// </summary>
    public partial class Equipment_pages : Page
    {
        public Equipment_pages()
        {
            InitializeComponent();
            InitializeEqupments();
        }

        private void InitializeEqupments()
        {
            var context = Helper.GetContext();
            Equipment_list.ItemsSource = context.Equipment.Include("Status_equipment").ToList();
        }
    }
}
