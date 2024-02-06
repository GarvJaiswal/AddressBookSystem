using System;
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
                Console.WriteLine("6. Search name in a City or State");
                Console.WriteLine("7. Search all names in a City");
                Console.WriteLine("8. Search all names in a State");
                //Console.WriteLine("9. Enter name of the city to get count of");
                //Console.WriteLine("10. Enter name of the state to get count of");
                Console.WriteLine("9. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "9")
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
                        {
                            Console.Write("Enter the first name you want to search for: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter the city in which you want to find the name: ");
                            string cname = Console.ReadLine();
                            Console.Write("Enter the state in which you want to find the name: ");
                            string sname = Console.ReadLine();
                            addressBookSystem.SearchContactInCityOrState(name, cname, sname);
                        }
                        break;

                    case "7":
                        {
                            Console.Write("Enter the city you want to find contacts of: ");
                            string cityName = Console.ReadLine();
                            addressBookSystem.SearchContactsByCity(cityName);
                        }
                        break;
                    case "8":
                        {
                            Console.Write("Enter the state you want to find contacts of: ");
                            string stateName = Console.ReadLine();
                            addressBookSystem.SearchContactsByState(stateName);
                        }
                        break;

                   /* case "9":
                        {
                            Console.Write("Enter the city name you want to get count of: ");
                            string cname = Console.ReadLine();
                            addressBookSystem.CountByCity(cname);
                        }
                        break;
                    case "10":
                        {
                            Console.Write("Enter the state name you want to get count of: ");
                            string sname = Console.ReadLine();
                            addressBookSystem.CountByState(sname);
                        }
                        break;*/
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
