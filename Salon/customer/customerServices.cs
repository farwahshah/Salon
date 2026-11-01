using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrownNGlowSalon.customer
{
    internal class customerServices
    {
        private customerRepo _repo = new customerRepo();

        public customerServices()
        {

        }

        public List<customerModel> GetAllData()
        {
            return _repo.Getcustomerfromfile();
        }

        public void SaveCustomer(customerModel customer)
        {
            _repo.SaveInFile(customer);
        }

        public customerModel SearchByName(string Name)
        {
            foreach (customerModel customer in _repo.Getcustomerfromfile())
            {
                if (customer.GetName() == Name)
                {
                    return customer;
                }
            }
            return null;
        }

        public bool UpdateCustomer(string targetName, customerModel updatedCustomer)
        {
            List<customerModel> customers = _repo.Getcustomerfromfile();
            foreach (customerModel c in customers)
            {
                if (c.GetName() == targetName)
                {
                    c.SetName(updatedCustomer.GetName());
                    c.SetAge(updatedCustomer.GetAge());
                    c.SetPhone(updatedCustomer.GetPhone());
                    c.SetMembership(updatedCustomer.GetMembership());
                    _repo.SaveallDataintoFile(customers);
                    return true;
                }
            }
            return false;
        }

        // A returning customer (same name) is updated, a new customer is saved
        public void RegisterCustomer(customerModel customer)
        {
            if (SearchByName(customer.GetName()) != null)
            {
                UpdateCustomer(customer.GetName(), customer);
            }
            else
            {
                SaveCustomer(customer);
            }
        }
    }
}
