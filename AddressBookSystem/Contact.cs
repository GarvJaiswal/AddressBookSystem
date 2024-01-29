using System;
using System.Collections.Generic;
namespace abc
{
    public class Contact
    {
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private string zipCode;
        private string phoneNumber;
        private string email;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public override string ToString()
        {
            return $"First name: {FirstName}\n" +
                $"Last name:{LastName}\n" +
                   $"Address: {Address}\n" +
                   $"City: {City}\n" +
                   $"State: {State}\n" +
                   $"Zip: {ZipCode}\n" +
                   $"Phone: {PhoneNumber}\n" +
                   $"Email: {Email}";
        }
    }

    public class AddressBook
    {
        private List<Contact> contacts = new List<Contact>();

        public string Name { get; }

        public AddressBook(string name)
        {
            Name = name;
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void DisplayContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts in this Address Book.");
            }
            else
            {
                Console.WriteLine($"Contacts in Address Book '{Name}':");
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact);
                    Console.WriteLine();
                }
            }
        }


        public void AddNewContact()
        {
            Contact contact = new Contact();
            Console.Write("Enter First Name: ");
            contact.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            contact.LastName = Console.ReadLine();
            Console.Write("Enter Address: ");
            contact.Address = Console.ReadLine();
            Console.Write("Enter City: ");
            contact.City = Console.ReadLine();
            Console.Write("Enter State: ");
            contact.State = Console.ReadLine();
            Console.Write("Enter Zip Code: ");
            contact.ZipCode = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            contact.PhoneNumber = Console.ReadLine();
            Console.Write("Enter Email: ");
            contact.Email = Console.ReadLine();
            contacts.Add(contact);
        }

        public void EditContact()
        {
            Console.Write("Enter First Name of the contact you want to edit: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name of the contact you want to edit: ");
            string lastName = Console.ReadLine();

            Contact existingContact = null;
            foreach (Contact contact in contacts)
            {
                if (contact.FirstName == firstName && contact.LastName == lastName)
                {
                    existingContact = contact;
                    break;
                }
            }

            // Contact existingContact = contacts.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
            if (existingContact != null)
            {
                Console.WriteLine("Enter\n1 to edit first name\n2 to edit last name\n3 to edit address\n4 to edit city\n5 to edit state\n6 to edit zipcode\n7 to edit phone number\n8 to edit email");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("Enter new First Name: ");
                        existingContact.FirstName = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Enter new Last Name: ");
                        existingContact.LastName = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Enter new Address: ");
                        existingContact.Address = Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Enter new City: ");
                        existingContact.City = Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Enter new State: ");
                        existingContact.State = Console.ReadLine();
                        break;
                    case 6:
                        Console.Write("Enter new Zip Code: ");
                        existingContact.ZipCode = Console.ReadLine();
                        break;
                    case 7:
                        Console.Write("Enter new Phone Number: ");
                        existingContact.PhoneNumber = Console.ReadLine();
                        break;
                    case 8:
                        Console.Write("Enter new Email: ");
                        existingContact.Email = Console.ReadLine();
                        break;
                }

            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        public void DeleteContact()
        {
            Console.Write("Enter First Name of the contact you want to delete: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name of the contact you want to delete: ");
            string lastName = Console.ReadLine();

            Contact contactToRemove = null;
            foreach (Contact contact in contacts)
            {
                if (contact.FirstName == firstName && contact.LastName == lastName)
                {
                    contactToRemove = contact;
                    break;
                }
            }

            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
                Console.WriteLine($"Contact {firstName} {lastName} deleted successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
    }

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