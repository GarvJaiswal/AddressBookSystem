using System;
using System.Collections.Generic;
namespace abc
{
    public class AddressBookSystem
    {
        private Dictionary<string, AddressBook> addressBooks = new Dictionary<string, AddressBook>();
        private AddressBook currentAddressBook;

        public void AddAddressBook(string name)
        {
            if (!addressBooks.ContainsKey(name))
            {
                addressBooks[name] = new AddressBook(name);
                Console.WriteLine($"Address Book '{name}' added successfully.");
            }
            else
            {
                Console.WriteLine($"Address Book '{name}' already exists.");
            }
        }

        public void SwitchAddressBook(string name)
        {
            if (addressBooks.ContainsKey(name))
            {
                currentAddressBook = addressBooks[name];
                Console.WriteLine($"Switched to Address Book '{name}'.");
            }
            else
            {
                Console.WriteLine($"Address Book '{name}' does not exist.");
            }
        }
        public void SearchContactInCityOrState(string name, string cname, string sname)
        {
            bool found = false;
            string nameLower = name.ToLower();
            string citysearchLower = cname.ToLower();
            string statesearchLower = sname.ToLower();

            foreach (var addressBook in addressBooks.Values)
            {
                List<Contact> foundContacts = addressBook.SearchInCityOrState(nameLower, citysearchLower, statesearchLower);
                if (foundContacts.Count > 0)
                {
                    Console.WriteLine("Contact found in ");
                    foreach (var contact in foundContacts)
                    {
                        Console.Write(contact.City + " city and" + contact.State + " state");
                        Console.WriteLine();
                    }
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine($"No contacts found with the name '{name}' in '{cname}' and '{sname}' in any address book.");
            }
        }
       
        public void SearchContactsByCity(string cityName)
        {
            bool foundInAnyAddressBook = false;
            foreach (var addressBook in addressBooks.Values)
            {
                List<Contact> foundContacts = addressBook.SearchByCity(cityName);
                if (foundContacts.Count > 0)
                {
                    Console.WriteLine($"Contacts found in Address Book '{addressBook.Name}' for city '{cityName}':");
                    foreach (var contact in foundContacts)
                    {
                        Console.WriteLine(contact);
                        Console.WriteLine();
                    }
                    foundInAnyAddressBook = true;
                }
            }

            if (!foundInAnyAddressBook)
            {
                Console.WriteLine($"No contacts found with the city '{cityName}' in any address book.");
            }
        }

        public void SearchContactsByState(string stateName)
        {
            bool foundInAnyAddressBook = false;
            foreach (var addressBook in addressBooks.Values)
            {
                List<Contact> foundContacts = addressBook.SearchByState(stateName);
                if (foundContacts.Count > 0)
                {
                    Console.WriteLine($"Contacts found in Address Book '{addressBook.Name}' for state '{stateName}':");
                    foreach (var contact in foundContacts)
                    {
                        Console.WriteLine(contact);
                        Console.WriteLine();
                    }
                    foundInAnyAddressBook = true;
                }
            }

            if (!foundInAnyAddressBook)
            {
                Console.WriteLine($"No contacts found with the state '{stateName}' in any address book.");
            }
        }

       /* public void CountByCity(string cityName)
        {
            int count = 0;
            string citysearchLower = cityName.ToLower();
            foreach (var addressBook in addressBooks.Values)
            {
                List<Contact> foundContacts = addressBook.CountByCityName(citysearchLower);

                if (foundContacts.Count > 0)
                {
                    count += foundContacts.Count;
                }
            }
            Console.WriteLine($"Contacts in city '{cityName}' are :" + count);
            if (count == 0)
                Console.WriteLine("No entries for " + cityName);
        }

        public void CountByState(string stateName)
        {
            int count = 0;
            string statesearchLower = stateName.ToLower();
            foreach (var addressBook in addressBooks.Values)
            {
                List<Contact> foundContacts = addressBook.CountByStateName(statesearchLower);

                if (foundContacts.Count > 0)
                {
                    count += foundContacts.Count;
                }
            }
            Console.WriteLine($"Contacts in state '{stateName}' are :" + count);
            if (count == 0)
                Console.WriteLine("No entries for " + stateName);


        }*/


        public void HandleUserChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    if (currentAddressBook != null)
                    {
                        currentAddressBook.AddNewContact();
                    }
                    else
                    {
                        Console.WriteLine("No address book selected.");
                    }
                    break;
                case "2":
                    if (currentAddressBook != null)
                    {
                        currentAddressBook.EditContact();
                    }
                    else
                    {
                        Console.WriteLine("No address book selected.");
                    }
                    break;
                case "3":
                    if (currentAddressBook != null)
                    {
                        currentAddressBook.DeleteContact();
                    }
                    else
                    {
                        Console.WriteLine("No address book selected.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public void DisplayCurrentAddressBook()
        {
            if (currentAddressBook != null)
            {
                currentAddressBook.DisplayContacts();
            }
            else
            {
                Console.WriteLine("No address book selected.");
            }
        }

    }
}
