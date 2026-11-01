using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace CrownNGlowSalon.category
{
    internal class categoryRepo
    {
        private readonly string file = "category.txt";
        public categoryRepo()
        {
            // first run: load the salon service categories
            if (!File.Exists(file))
            {
                LoadSampleData();
            }
        }

        private void LoadSampleData()
        {
            List<categoryModel> samples = new List<categoryModel>();
            samples.Add(new categoryModel("i", "Hair Style Station"));
            samples.Add(new categoryModel("ii", "Glow Studio"));
            samples.Add(new categoryModel("iii", "Nail Fusion"));
            samples.Add(new categoryModel("iv", "Skin Touch"));
            samples.Add(new categoryModel("v", "Spa Lounge"));
            samples.Add(new categoryModel("vi", "Body Care"));
            samples.Add(new categoryModel("vii", "Hair Revival"));
            samples.Add(new categoryModel("viii", "Bridal Elegance"));
            SaveallDataintoFile(samples);
        }

        public void SaveInFile(categoryModel category)
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(category.ToString());
            }
        }

        public void SaveallDataintoFile(List<categoryModel> categories)
        {
            File.WriteAllText(file, string.Empty);
            foreach (var category in categories)
            {
                SaveInFile(category);
            }
        }

        //{categoryCode},{categoryName}
        public List<categoryModel> Getcategoryfromfile()
        {
            List<categoryModel> categorylists = new List<categoryModel>();
            if (!File.Exists(file))
            {
                return categorylists;
            }
            using (StreamReader stream = new StreamReader(file))
            {
                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string categoryCode = parts[0];
                    string categoryName = parts[1];

                    categoryModel categorymodel = new categoryModel(categoryCode, categoryName);
                    categorylists.Add(categorymodel);
                }
            }
            return categorylists;
        }
    }
}
