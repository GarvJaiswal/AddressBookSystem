using System;
using System.Collections.Generic;

namespace AddressBook
{
    class AddressBook
    {
        class Contact
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Zip { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
        }

        static void Main()
        {
            List<Contact> addressBook = new List<Contact>();

            Console.WriteLine("Welcome to Address Book");

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add New Contact");
                Console.WriteLine("2. Edit Existing Contact");
                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice (1-3): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewContact(addressBook);
                        break;
                    case "2":
                        EditExistingContact(addressBook);
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                        break;
                }
            }
        }

        static void AddNewContact(List<Contact> addressBook)
        {
            Contact newContact = new Contact();

            Console.WriteLine("\nEnter Contact Details:");

            Console.Write("Enter the First name: ");
            newContact.FirstName = Console.ReadLine();

            Console.Write("Enter the Last Name: ");
            newContact.LastName = Console.ReadLine();

            Console.Write("Enter the address: ");
            newContact.Address = Console.ReadLine();

            Console.Write("Enter the city: ");
            newContact.City = Console.ReadLine();

            Console.Write("Enter the zip: ");
            newContact.Zip = Console.ReadLine();

            Console.Write("Enter the email: ");
            newContact.Email = Console.ReadLine();

            Console.Write("Enter the phone number: ");
            newContact.PhoneNumber = Console.ReadLine();

            addressBook.Add(newContact);

            Console.WriteLine("Contact added successfully.");
            DisplayContactDetails(newContact);
        }

        static void EditExistingContact(List<Contact> addressBook)
        {
            Console.Write("Enter the First name of the contact to edit: ");
            string firstNameToEdit = Console.ReadLine();

            Contact existingContact = addressBook.Find(contact => contact.FirstName.Equals(firstNameToEdit, StringComparison.OrdinalIgnoreCase));

            if (existingContact != null)
            {
                Console.WriteLine("Edit Contact Details:");

                Console.Write("Enter the new First name: ");
                existingContact.FirstName = Console.ReadLine();

                Console.Write("Enter the new Last Name: ");
                existingContact.LastName = Console.ReadLine();

                Console.Write("Enter the new address: ");
                existingContact.Address = Console.ReadLine();

                Console.Write("Enter the new city: ");
                existingContact.City = Console.ReadLine();

                Console.Write("Enter the new zip: ");
                existingContact.Zip = Console.ReadLine();

                Console.Write("Enter the new email: ");
                existingContact.Email = Console.ReadLine();

                Console.Write("Enter the new phone number: ");
                existingContact.PhoneNumber = Console.ReadLine();

                Console.WriteLine("Contact edited successfully.");
                DisplayContactDetails(existingContact);
            }
            else
            {
                Console.WriteLine($"Contact with First Name '{firstNameToEdit}' not found.");
            }
        }

        static void DisplayContactDetails(Contact contact)
        {
            Console.WriteLine("\nContact Details:");
            Console.WriteLine($"First Name: {contact.FirstName}");
            Console.WriteLine($"Last Name: {contact.LastName}");
            Console.WriteLine($"City: {contact.City}");
            Console.WriteLine($"Zip: {contact.Zip}");
            Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.ReadLine();
        }
    }
}
