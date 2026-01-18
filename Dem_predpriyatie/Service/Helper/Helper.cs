using Dem_predpriyatie.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem_predpriyatie.Service.Helper
{
    public class Helper
    {
        private static predEnt context;
        public static predEnt GetContext()
        {
            if (context == null)
            {
                context = new predEnt();
            }
            return context;
        }
    }
}
