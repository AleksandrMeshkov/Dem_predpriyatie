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
            load_post();
        }

        private void load_post()
        {
            var purchases = context.Purchase
                .Include("Warehouse.Specification.Recipe.Materials")
                .ToList();

            var displayModels = purchases.Select(p =>
            {
                var specs = (p.Warehouse ?? Enumerable.Empty<Warehouse>())
                    .SelectMany(w => w.Specification ?? Enumerable.Empty<Specification>());

                var orderedSpecs = specs.OrderBy(s => s.Specification_id).ToList();
                var materialName = orderedSpecs
                    .Select(s => s.Recipe?.Materials?.Name)
                    .FirstOrDefault() ?? "Материал не указан";

                var totalRemains = specs.Sum(s => (int?)s.Remains) ?? 0;

                return new PurchaseDisplayModel
                {
                    Date = p.Date,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    MaterialName = materialName,
                    Remains = totalRemains
                };
            }).ToList();

            Post_list.ItemsSource = displayModels;
        }

        public class PurchaseDisplayModel
        {
            public DateTime Date { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public string MaterialName { get; set; }
            public int Remains { get; set; } 
        }
    }
}
