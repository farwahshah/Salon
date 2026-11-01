using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CrownNGlowSalon.service
{
    internal class serviceModel
    {
        private string categoryCode;
        private string serviceName;
        private int Price;

        public serviceModel()
        {

        }
        public serviceModel(string serviceName)
        {
            this.serviceName = serviceName;
        }

        public serviceModel(string categoryCode, string serviceName, int Price)
        {
            this.categoryCode = categoryCode;
            this.serviceName = serviceName;
            this.Price = Price;
        }

        public void SetCategoryCode(string categoryCode)
        {
            this.categoryCode = categoryCode;
        }
        public string GetCategoryCode()
        {
            return categoryCode;
        }

        public void SetServiceName(string serviceName)
        {
            this.serviceName = serviceName;
        }
        public string GetServiceName()
        {
            return serviceName;
        }

        public void SetPrice(int Price)
        {
            this.Price = Price;
        }
        public int GetPrice()
        {
            return Price;
        }

        public override string ToString()
        {
            return $"{categoryCode},{serviceName},{Price}";
        }
    }
}
