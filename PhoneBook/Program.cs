using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PhoneBook;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Book.Display();
                Router.RunProcess();
                Console.ReadKey();
            }
        }
    }
}

class Router
{
    public static void RunProcess()
    {
        DisplayOptions();
    }

    public static void DisplayOptions()
    {
        Console.WriteLine("\nSelect operation... \n");
        Console.WriteLine("1 - Add new record.");
        Console.WriteLine("2 - Edit record.");
        Console.WriteLine("3 - Delete record.");
        Console.WriteLine("4 - Order records by name.");
        Console.WriteLine("5 - Order records by number.");
        Console.WriteLine("6 - Search in records by name.");
        Console.WriteLine("7 - Search in records by number.");

        var route = Console.ReadLine();

        if (!Regex.IsMatch(route.ToString(), "^[1-7]$"))
        {
            Console.WriteLine("\n\n You made a wrong choice! Try again..");
            DisplayOptions();
        }

        RunFunc(int.Parse(route) - 1);
    }

    public static void RunFunc(int index)
    {
        ArrayList functions = Book.GetFuncList();
        Action function = (Action)functions[index];
        function();
    }
}