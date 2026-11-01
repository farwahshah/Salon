using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace CrownNGlowSalon.customer
{
    internal class customerRepo
    {
        private readonly string file = "customer.txt";
        public customerRepo()
        {
        }

        public void SaveInFile(customerModel customer)
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(customer.ToString());
            }
        }

        public void SaveallDataintoFile(List<customerModel> customers)
        {
            File.WriteAllText(file, string.Empty);
            foreach (var customer in customers)
            {
                SaveInFile(customer);
            }
        }

        //{customerName},{Age},{Phone},{Membership}
        public List<customerModel> Getcustomerfromfile()
        {
            List<customerModel> customerlists = new List<customerModel>();
            if (!File.Exists(file))
            {
                return customerlists;
            }
            using (StreamReader stream = new StreamReader(file))
            {
                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string customerName = parts[0];
                    int Age = int.Parse(parts[1]);
                    string Phone = parts[2];
                    string Membership = parts[3];

                    customerModel customermodel = new customerModel(customerName, Age, Phone, Membership);
                    customerlists.Add(customermodel);
                }
            }
            return customerlists;
        }
    }
}