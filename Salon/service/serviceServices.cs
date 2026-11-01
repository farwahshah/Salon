using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CrownNGlowSalon.service
{
    internal class serviceServices
    {
        private serviceRepo _repo = new serviceRepo();

        public serviceServices()
        {

        }

        public List<serviceModel> getAllServices()
        {
            return _repo.Getservicefromfile();
        }

        // all services that belong to one category (i, ii, iii ...)
        public List<serviceModel> getServicesByCategory(string categoryCode)
        {
            List<serviceModel> result = new List<serviceModel>();
            if (categoryCode == null)
            {
                return result;
            }
            categoryCode = categoryCode.Trim().ToLower();
            foreach (serviceModel s in _repo.Getservicefromfile())
            {
                if (s.GetCategoryCode() == categoryCode)
                {
                    result.Add(s);
                }
            }
            return result;
        }

        // op is the number the customer selects (1, 2, 3 ...)
        // returns null if the number is outside the list
        public serviceModel getService(string categoryCode, int op)
        {
            List<serviceModel> list = getServicesByCategory(categoryCode);
            if (op >= 1 && op <= list.Count)
            {
                return list[op - 1];
            }
            return null;
        }
    }
}
