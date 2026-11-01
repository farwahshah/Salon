
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CrownNGlowSalon.category;

namespace CrownNGlowSalon.service
{
    internal class serviceUI
    {
        private serviceServices serviceService = new serviceServices();
        private categoryServices categoryService = new categoryServices();

        // one function for all 8 categories (replaces showHairStation, showGlowStudio, ...)
        public void showServices(string categoryCode)
        {
            categoryModel category = categoryService.findByCode(categoryCode);
            if (category == null)
            {
                Console.WriteLine(" Category not found.");
                return;
            }

            Console.WriteLine("\n " + category.GetName().ToUpper());
            List<serviceModel> list = serviceService.getServicesByCategory(categoryCode);
            for (int i = 0; i < list.Count; i++)
            {
                serviceModel s = list[i];
                Console.WriteLine(" " + (i + 1) + ". " + s.GetServiceName() + " - RS " + s.GetPrice());
            }
        }
    }
}