using CrownNGlowSalon.booking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Salon.booking
{
    internal class bookingRepo
    {
        private readonly string file = "booking.txt";
        public bookingRepo()
        {
        }

        public void SaveInFile(bookingModel booking)
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(booking.ToString());
            }
        }

        public void SaveallDataintoFile(List<bookingModel> bookings)
        {
            File.WriteAllText(file, string.Empty);
            foreach (var booking in bookings)
            {
                SaveInFile(booking);
            }
        }

        //{customerName},{serviceName},{Appointment},{Bill}
        public List<bookingModel> Getbookingfromfile()
        {
            List<bookingModel> bookinglists = new List<bookingModel>();
            if (!File.Exists(file))
            {
                return bookinglists;
            }
            using (StreamReader stream = new StreamReader(file))
            {
                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string customerName = parts[0];
                    string serviceName = parts[1];
                    string Appointment = parts[2];
                    int Bill = int.Parse(parts[3]);

                    bookingModel bookingmodel = new bookingModel(customerName, serviceName, Appointment, Bill);
                    bookinglists.Add(bookingmodel);
                }
            }
            return bookinglists;
        }
    }
}

