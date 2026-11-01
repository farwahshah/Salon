using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrownNGlowSalon.customer
{
    internal class customerModel
    {
        private string customerName;
        private int Age;
        private string Phone;
        private string Membership;

        public customerModel()
        {

        }
        public customerModel(string customerName)
        {
            this.customerName = customerName;
        }

        public customerModel(string customerName, int Age, string Phone, string Membership)
        {
            this.customerName = customerName;
            this.Age = Age;
            this.Phone = Phone;
            this.Membership = Membership;
        }

        public void SetName(string customerName)
        {
            this.customerName = customerName;
        }
        public string GetName()
        {
            return customerName;
        }

        public void SetAge(int Age)
        {
            this.Age = Age;
        }
        public int GetAge()
        {
            return Age;
        }

        public void SetPhone(string Phone)
        {
            this.Phone = Phone;
        }
        public string GetPhone()
        {
            return Phone;
        }

        public void SetMembership(string Membership)
        {
            this.Membership = Membership;
        }
        public string GetMembership()
        {
            return Membership;
        }

        public override string ToString()
        {
            return $"{customerName},{Age},{Phone},{Membership}";
        }
    }
}