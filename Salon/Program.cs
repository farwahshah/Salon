using CrownNGlowSalon.booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;


namespace CrownNGlowSalon
{
    internal class MainUI
    {
        public void Start()
        {
            while (true)
            {
                Console.Clear();
                showHeading();
                string option = MainMenu();
                if (option == "1")
                {
                    adminUI adminUI = new adminUI();
                    adminUI.adminDriver();
                }
                else if (option == "2")
                {
                    bookingUI bookingUI = new bookingUI();
                    bookingUI.bookService();
                    Helper.pause();
                }
                else if (option == "3")
                {
                    Console.WriteLine("\n Goodbye! Have a great day :)");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong option selected");
                    Console.ReadKey();
                }
            }
        }

        public void showHeading()
        {
            Console.WriteLine(". . . . . . . . . . . . . . . .");
            Console.WriteLine("   * * *  CROWN n GLOW  * * *  ");
            Console.WriteLine("           S A L O N           ");
            Console.WriteLine(". . . . . . . . . . . . . . . .");
        }

        public string MainMenu()
        {
            Console.WriteLine("\n ===== MAIN MENU =====");
            Console.WriteLine("1 to Admin");
            Console.WriteLine("2 to Customer");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3 to Exit");
            Console.ForegroundColor = ConsoleColor.White;
            string option = Console.ReadLine();
            return option;
        }
    }

    internal class adminUI
    {
        private bookingUI bookingScreen = new bookingUI();

        public void adminDriver()
        {
            string pass = Helper.readText(" Enter password: ");
            if (pass != "admin123")
            {
                Console.WriteLine(" Wrong password!");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                Console.Clear();
                string option = adminMenu();
                if (option == "1")
                {
                    bookingScreen.viewAllRecords();
                    Helper.pause();
                }
                else if (option == "2")
                {
                    bookingScreen.showTotalRevenue();
                    Helper.pause();
                }
                else if (option == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong option selected");
                    Console.ReadKey();
                }
            }
        }

        public string adminMenu()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("-------------- ADMIN -----------------");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1) View All Records");
            Console.WriteLine("2) Total Revenue");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3) Back");
            Console.ForegroundColor = ConsoleColor.White;
            string option = Console.ReadLine();
            return option;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MainUI ui = new MainUI();
            ui.Start();
        }
    }
}