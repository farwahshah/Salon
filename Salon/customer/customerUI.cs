using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;


namespace CrownNGlowSalon.customer
{
    internal class customerUI
    {
        // asks name, age and phone (membership is asked separately, see TakeMembership)
        public customerModel TakeInput()
        {
            string name = Helper.readText(" Enter your name: ");
            int age = Helper.readInt(" Enter your age: ");
            string phone = Helper.readText(" Enter your phone number: ");

            customerModel customer = new customerModel(name, age, phone, "No");
            return customer;
        }

        public string TakeMembership()
        {
            string membership = Helper.readText(" Do you have membership? (Yes/No): ");
            return membership;
        }
    }
}