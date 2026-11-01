using CrownNGlowSalon.booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Salon.booking
{
    internal class bookingServices
    {
        private bookingRepo _repo = new bookingRepo();

        public bookingServices()
        {

        }

        public List<bookingModel> getAllBookings()
        {
            return _repo.Getbookingfromfile();
        }

        public int getCount()
        {
            return _repo.Getbookingfromfile().Count;
        }

        public void saveBooking(bookingModel booking)
        {
            _repo.SaveInFile(booking);
        }

        // Members get 10% off. Returns the final bill.
        public int calculateBill(int bill, string membership)
        {
            if (membership == "Yes" || membership == "yes")
            {
                int discount = bill / 10;
                bill = bill - discount;
            }
            return bill;
        }

        public int getTotalRevenue()
        {
            int total = 0;
            foreach (bookingModel b in _repo.Getbookingfromfile())
            {
                total = total + b.GetBill();
            }
            return total;
        }
    }
}
