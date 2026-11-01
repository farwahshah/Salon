using CrownNGlowSalon.category;
using CrownNGlowSalon.customer;
using CrownNGlowSalon.service;
using Salon.booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CrownNGlowSalon.booking
{
    internal class bookingUI
    {
        private categoryUI categoryScreen = new categoryUI();
        private serviceUI serviceScreen = new serviceUI();
        private customerUI customerScreen = new customerUI();

        private categoryServices categoryService = new categoryServices();
        private serviceServices serviceService = new serviceServices();
        private customerServices customerService = new customerServices();
        private bookingServices bookingService = new bookingServices();

        // ---- Customer: choose a service, enter details, get the receipt ----
        public void bookService()
        {
            categoryScreen.showCustomerMenu();
            string code = Console.ReadLine();
            if (code == null)
            {
                code = "";
            }
            code = code.Trim().ToLower();

            categoryModel category = categoryService.findByCode(code);
            if (category == null)
            {
                Console.WriteLine(" Invalid service!");
                return;
            }

            serviceScreen.showServices(code);
            int count = serviceService.getServicesByCategory(code).Count;
            int op = Helper.readInt(" Select (1-" + count + "): ");

            serviceModel chosen = serviceService.getService(code, op);
            if (chosen == null)
            {
                Console.WriteLine(" Invalid option!");
                return;
            }

            // ---- Customer Info ----
            Console.WriteLine();
            customerModel customer = customerScreen.TakeInput();
            string appointment = Helper.readText(" Appointment (Walkin/Home): ");
            customer.SetMembership(customerScreen.TakeMembership());
            customerService.RegisterCustomer(customer);

            // ---- Bill Calculation ----
            int bill = chosen.GetPrice();
            int finalBill = bookingService.calculateBill(bill, customer.GetMembership());
            if (finalBill < bill)
            {
                Console.WriteLine(" 10% discount applied! (-RS " + (bill - finalBill) + ")");
            }

            bookingService.saveBooking(new bookingModel(customer.GetName(), chosen.GetServiceName(), appointment, finalBill));

            // ---- Receipt ----
            printReceipt(customer.GetName(), chosen.GetServiceName(), appointment, customer.GetMembership(), finalBill);
        }

        public void printReceipt(string name, string chosen, string appointment, string membership, int bill)
        {
            Console.WriteLine("\n ==============================");
            Console.WriteLine("     CROWN n GLOW SALON        ");
            Console.WriteLine("           RECEIPT             ");
            Console.WriteLine(" ==============================");
            Console.WriteLine(" Name        : " + name);
            Console.WriteLine(" Service     : " + chosen);
            Console.WriteLine(" Appointment : " + appointment);
            Console.WriteLine(" Membership  : " + membership);
            Console.WriteLine(" ------------------------------");
            Console.WriteLine(" TOTAL BILL  : RS " + bill);
            Console.WriteLine(" ==============================");
            Console.WriteLine(" Thank you for visiting us! :) ");
        }

        // ---- Admin: view all records ----
        public void viewAllRecords()
        {
            List<bookingModel> list = bookingService.getAllBookings();
            if (list.Count == 0)
            {
                Console.WriteLine(" No records yet.");
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                bookingModel b = list[i];
                customerModel c = customerService.SearchByName(b.GetCustomerName());

                string age = "-";
                string phone = "-";
                string membership = "-";
                if (c != null)
                {
                    age = c.GetAge().ToString();
                    phone = c.GetPhone();
                    membership = c.GetMembership();
                }

                Console.WriteLine("\n Record #" + (i + 1));
                Console.WriteLine(" Name        : " + b.GetCustomerName());
                Console.WriteLine(" Age         : " + age);
                Console.WriteLine(" Phone       : " + phone);
                Console.WriteLine(" Service     : " + b.GetServiceName());
                Console.WriteLine(" Appointment : " + b.GetAppointment());
                Console.WriteLine(" Membership  : " + membership);
                Console.WriteLine(" Bill        : RS " + b.GetBill());
                Console.WriteLine(" ----------------------------");
            }
        }

        // ---- Admin: total revenue ----
        public void showTotalRevenue()
        {
            Console.WriteLine(" Total Customers : " + bookingService.getCount());
            Console.WriteLine(" Total Revenue   : RS " + bookingService.getTotalRevenue());
        }
    }
}