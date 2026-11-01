using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CrownNGlowSalon.category
{
    internal class categoryServices
    {
        private categoryRepo _repo = new categoryRepo();

        public categoryServices()
        {

        }

        public List<categoryModel> getAllCategories()
        {
            return _repo.Getcategoryfromfile();
        }

        public int getCount()
        {
            return _repo.Getcategoryfromfile().Count;
        }

        // finds a category from the code the customer types (i, ii, iii ...)
        public categoryModel findByCode(string code)
        {
            if (code == null)
            {
                return null;
            }
            code = code.Trim().ToLower();
            foreach (categoryModel c in _repo.Getcategoryfromfile())
            {
                if (c.GetCode() == code)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
