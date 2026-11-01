
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CrownNGlowSalon
{
    // small helpers shared by every UI class (static)
    internal class Helper
    {
        public static void pause()
        {
            Console.WriteLine(" Press any key...");
            Console.ReadKey();
        }

        // commas are replaced by spaces because the text files use commas to separate fields
        public static string readText(string label)
        {
            Console.Write(label);
            string text = Console.ReadLine();
            if (text == null)
            {
                text = "";
            }
            return text.Replace(",", " ").Trim();
        }

        // returns 0 if the user types something that is not a number
        public static int readInt(string label)
        {
            Console.Write(label);
            int value;
            if (int.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }
            return 0;
        }
    }
}