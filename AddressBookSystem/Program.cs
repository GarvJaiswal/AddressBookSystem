using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
namespace abc
{
    class Program
    {
        static void Main()
        {
            AddressBookSystem addressBookSystem = new AddressBookSystem();

            // Adding address books
            Console.Write("Enter the name for the first address book: ");
            string addressBookName1 = Console.ReadLine();
            addressBookSystem.AddAddressBook(addressBookName1);

            Console.Write("Enter the name for the second address book: ");
            string addressBookName2 = Console.ReadLine();
            addressBookSystem.AddAddressBook(addressBookName2);

            // Switching to first address book
            addressBookSystem.SwitchAddressBook(addressBookName1);

            while (true)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Display Contacts");
                Console.WriteLine("5. Switch Address Book");
                Console.WriteLine("6. Search");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "7")
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }

                switch (choice)
                {
                    case "1":
                    case "2":
                    case "3":
                        addressBookSystem.HandleUserChoice(choice);
                        break;
                    case "4":
                        addressBookSystem.DisplayCurrentAddressBook();
                        break;
                    case "5":
                        Console.Write("Enter the name of the address book you want to switch to: ");
                        string switchTo = Console.ReadLine();
                        addressBookSystem.SwitchAddressBook(switchTo);
                        break;
                    case "6":
                        Console.Write("Enter the city you want to find contacts of: ");
                        string cname=Console.ReadLine();
                        Console.Write("Enter the state you want to find contacts of: ");
                        string sname = Console.ReadLine();
                        addressBookSystem.SearchContactByCityName(cname,sname);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
