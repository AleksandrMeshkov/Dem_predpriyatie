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


namespace Dem_predpriyatie.Pages_list
{
    /// <summary>
    /// Логика взаимодействия для Post_materials.xaml
    /// </summary>
    public partial class Post_materials : Page
    {
        private predEnt context = new predEnt();
        public Post_materials()
        {
            InitializeComponent();
        }

        private void load_post()
        {
            var postcard = context.Purchase
                .Select(p => new
                {
                    p.Date,
                    p.Price,
                    p.Quantity,

                }).ToList();
        }
    }
}
