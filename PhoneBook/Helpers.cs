using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PhoneBook
{
    class Helpers
    {
        public static string GetInputFromUser(string inputArea)
        {
            Console.WriteLine(inputArea + ": ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("You entered an incorrect value! Try again.");
                return GetInputFromUser(inputArea);
            }

            return input;
        }

        public static int GetIndexFromUser()
        {
            Console.WriteLine("Which line is the record you want to process?");
            var index = Console.ReadLine();
            if (!Regex.IsMatch(index, "[1-9]") || int.Parse(index) > Book.GetContactsCount())
            {
                Console.WriteLine("You entered an incorrect value! Try again.");
                return GetIndexFromUser();
            }

            return int.Parse(index) - 1;
        }
    }
}
