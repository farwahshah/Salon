using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CrownNGlowSalon.category
{
    internal class categoryModel
    {
        private string categoryCode;
        private string categoryName;

        public categoryModel()
        {

        }
        public categoryModel(string categoryCode)
        {
            this.categoryCode = categoryCode;
        }

        public categoryModel(string categoryCode, string categoryName)
        {
            this.categoryCode = categoryCode;
            this.categoryName = categoryName;
        }

        public void SetCode(string categoryCode)
        {
            this.categoryCode = categoryCode;
        }
        public string GetCode()
        {
            return categoryCode;
        }

        public void SetName(string categoryName)
        {
            this.categoryName = categoryName;
        }
        public string GetName()
        {
            return categoryName;
        }

        public override string ToString()
        {
            return $"{categoryCode},{categoryName}";
        }
    }
}