using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PhoneBook
{
    class Book
    {
        public static void Display(ArrayList contacts = null, string message = null)
        {
            if (contacts == null)
                contacts = BookUtils._contacts;
            
            if (message == null)            
                message = "CONTACTS";            

            int row = 1;
            Console.WriteLine("*****************************************************************");
            Console.WriteLine(message);
            foreach (Contact contact in contacts)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(row + " | " + contact.Name + " - " + contact.Number);
                Console.WriteLine("-------------------------------------------------");
                row++;
            }
            Console.WriteLine("*****************************************************************");
        }

        public static void AddNew()
        {
            Contact contact = new Contact();

            contact.Name = Helpers.GetInputFromUser("Name: ");
            contact.Number = Helpers.GetInputFromUser("Number: ");

            BookUtils._contacts.Add(contact);
        }

        public static void Delete()
        {
            int index = Helpers.GetIndexFromUser();
            BookUtils._contacts.RemoveAt(index);
        }

        public static void Edit()
        {
            int index = Helpers.GetIndexFromUser();
            Contact contact = (Contact)BookUtils._contacts[index];
            Console.WriteLine("------------");
            Console.WriteLine("Current Name: " + contact.Name);
            Console.WriteLine("Current Number: " + contact.Number);
            Console.WriteLine("------------");

            Console.WriteLine("If don not want to edit please type \"-\"");

            string name = Helpers.GetInputFromUser("New Name: ");
            contact.Name = name == "-" ? contact.Name : name;

            string number = Helpers.GetInputFromUser("New Number: ");
            contact.Number = number == "-" ? contact.Number : number;
        }

        public static void SearchByNumber()
        {
            SearchAndDisplay("Number", "Search by number: ");
        }

        public static void SearchByName()
        {
            SearchAndDisplay("Name", "Search by name: ");
        }

        public static void SearchAndDisplay(string searchByProperty, string getInputMessage)
        {
            string name = Helpers.GetInputFromUser(getInputMessage);
            ArrayList contacts = new ArrayList();

            foreach (Contact contact in BookUtils._contacts)
            {
                var currentName = contact.GetType().GetProperty(searchByProperty).GetValue(contact, null).ToString();

                if (currentName.ToLower().Contains(name.ToLower()))
                {
                    contacts.Add(contact);
                }
            }

            if (contacts.Count > 0)
            {
                Display(contacts, "Search Results");
            }
            else
            {
                Console.WriteLine("No matching contacts found!");
            }
        }
        
        public static void SortByNumber()
        {
            BookUtils._contacts.Sort(new NumberComparer());
        }

        public static void SortByName()
        {
            BookUtils._contacts.Sort(new NameComparer());
        }

        public static ArrayList GetFuncList()
        {
            return BookUtils._functions;
        }

        public static int GetContactsCount()
        {
            return BookUtils._contacts.Count;
        }

        class BookUtils
        {
            public static ArrayList _contacts =
                new ArrayList
                {
                    new Contact
                    {
                        Name = "Tevfik Yüksel",
                        Number = "0123123121"
                    },
                    new Contact
                    {
                        Name = "Ali Demir",
                        Number = "01111111111"

                    },
                    new Contact
                    {
                        Name = "Ayşe Bakır",
                        Number = "05555555555"
                    },
                };
            
            public static ArrayList _functions = 
                new ArrayList
                {
                    new Action(Book.AddNew),
                    new Action(Book.Edit),
                    new Action(Book.Delete),
                    new Action(Book.SortByName),
                    new Action(Book.SortByNumber),
                    new Action(Book.SearchByName),
                    new Action(Book.SearchByNumber),
                };
        }
    }

    class NameComparer : IComparer
    {
        int IComparer.Compare(object conx, object cony)
        {
            Contact x = (Contact)conx;
            Contact y = (Contact)cony;

            return x.Name.CompareTo(y.Name);
        }
    }

    class NumberComparer : IComparer
    {
        int IComparer.Compare(object conx, object cony)
        {
            Contact x = (Contact)conx;
            Contact y = (Contact)cony;

            return x.Number.CompareTo(y.Number);
        }
    }
}
