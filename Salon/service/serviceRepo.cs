using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace CrownNGlowSalon.service
{
    internal class serviceRepo
    {
        private readonly string file = "service.txt";
        public serviceRepo()
        {
            // first run: load the salon price list
            if (!File.Exists(file))
            {
                LoadSampleData();
            }
        }

        private void LoadSampleData()
        {
            List<serviceModel> samples = new List<serviceModel>();

            // i. Hair Style Station
            samples.Add(new serviceModel("i", "U Cut", 700));
            samples.Add(new serviceModel("i", "V Cut", 800));
            samples.Add(new serviceModel("i", "Layering", 1500));
            samples.Add(new serviceModel("i", "Bangs", 1400));
            samples.Add(new serviceModel("i", "Bob Cut", 700));

            // ii. Glow Studio
            samples.Add(new serviceModel("ii", "Skin Polish", 1500));
            samples.Add(new serviceModel("ii", "Facial", 1300));
            samples.Add(new serviceModel("ii", "Threading", 700));
            samples.Add(new serviceModel("ii", "Waxing", 750));

            // iii. Nail Fusion
            samples.Add(new serviceModel("iii", "Nail Shaping", 800));
            samples.Add(new serviceModel("iii", "Manicure", 1000));
            samples.Add(new serviceModel("iii", "Pedicure", 1000));

            // iv. Skin Touch
            samples.Add(new serviceModel("iv", "Party Makeup", 3000));
            samples.Add(new serviceModel("iv", "Day Makeup", 2000));
            samples.Add(new serviceModel("iv", "HD Makeup", 2500));

            // v. Spa Lounge
            samples.Add(new serviceModel("v", "Massage Spa", 1000));
            samples.Add(new serviceModel("v", "Detox Spa", 2000));
            samples.Add(new serviceModel("v", "Medical Spa", 3500));

            // vi. Body Care
            samples.Add(new serviceModel("vi", "Body Bleaching", 5000));
            samples.Add(new serviceModel("vi", "Full Body Hair Remove", 5000));

            // vii. Hair Revival
            samples.Add(new serviceModel("vii", "Keratin", 8000));
            samples.Add(new serviceModel("vii", "Rebonding", 7000));
            samples.Add(new serviceModel("vii", "Cysteine Treatment", 7500));

            // viii. Bridal Elegance
            samples.Add(new serviceModel("viii", "Wedding Makeup", 30000));
            samples.Add(new serviceModel("viii", "Nikkah Makeup", 15000));
            samples.Add(new serviceModel("viii", "Mehndi Makeup", 20000));
            samples.Add(new serviceModel("viii", "Reception Makeup", 25000));

            SaveallDataintoFile(samples);
        }

        public void SaveInFile(serviceModel service)
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(service.ToString());
            }
        }

        public void SaveallDataintoFile(List<serviceModel> services)
        {
            File.WriteAllText(file, string.Empty);
            foreach (var service in services)
            {
                SaveInFile(service);
            }
        }

        //{categoryCode},{serviceName},{Price}
        public List<serviceModel> Getservicefromfile()
        {
            List<serviceModel> servicelists = new List<serviceModel>();
            if (!File.Exists(file))
            {
                return servicelists;
            }
            using (StreamReader stream = new StreamReader(file))
            {
                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string categoryCode = parts[0];
                    string serviceName = parts[1];
                    int Price = int.Parse(parts[2]);

                    serviceModel servicemodel = new serviceModel(categoryCode, serviceName, Price);
                    servicelists.Add(servicemodel);
                }
            }
            return servicelists;
        }
    }
}