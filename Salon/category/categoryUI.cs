using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CrownNGlowSalon.category
{
    internal class categoryUI
    {
        private categoryServices service = new categoryServices();

        public void showCustomerMenu()
        {
            Console.WriteLine("\n Welcome to Crown n Glow Salon!");
            List<categoryModel> list = service.getAllCategories();
            foreach (categoryModel c in list)
            {
                Console.WriteLine(" " + (c.GetCode() + ".").PadRight(6) + c.GetName());
            }
            Console.Write(" Select service: ");
        }
    }
}
