using abc;
using System;
using System.Collections.Generic;
using System.IO;


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

    public void WriterToFile(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        {
            using (StreamWriter writer = new StreamWriter(fs))
            {
                foreach (var item in contacts)
                {
                    writer.Write($"{item.FirstName},{item.LastName},{item.Address},{item.City},{item.State},{item.ZipCode},{item.PhoneNumber},{item.Email}");
                    writer.WriteLine();
                }
            }
        }
        Console.WriteLine("Data written to file successfully");
    }



        public void AddNewContact()
        {
            Contact contact = new Contact();
            Console.Write("Enter First Name: ");
            string FirstName = Console.ReadLine();

            foreach (Contact detail in contacts)
            {
                if (detail.FirstName == FirstName)
                {
                    Console.WriteLine("Duplicate entry");
                    return;
                }
            }

            contact.FirstName = FirstName;
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
        public Contact NewContactDetailsToWriteToFile()
        {


            Contact contact = new Contact();
            Console.Write("Enter First Name: ");
            string FirstName = Console.ReadLine();

            foreach (Contact detail in contacts)
            {
                if (detail.FirstName == FirstName)
                {
                    Console.WriteLine("Duplicate entry");

                }
            }

            contact.FirstName = FirstName;
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

            return contact;
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

    public List<Contact> SearchInCityOrState(string name, string city, string state)
    {
        List<Contact> foundContacts = new List<Contact>();
        string nameLower = name.ToLower();
        string cityLower = city.ToLower();
        string stateLower = state.ToLower();
        foreach (var contact in contacts)
        {
            string Namelower = contact.FirstName.ToLower();
            string Citylower = city.ToLower();
            string Statelower = state.ToLower();
            if (Namelower.Equals(nameLower) && (Citylower.Equals(cityLower) || Statelower.Equals(stateLower)))
            {
                foundContacts.Add(contact);
            }
        }
        return foundContacts;
    }

    public List<Contact> SearchByCity(string cityName)
    {
        List<Contact> foundContacts = new List<Contact>();
        string cityLower = cityName.ToLower();
        foreach (var contact in contacts)
        {
            if (contact.City.ToLower() == cityLower)
            {
                foundContacts.Add(contact);
            }
        }
        return foundContacts;
    }

    public List<Contact> SearchByState(string stateName)
    {
        List<Contact> foundContacts = new List<Contact>();
        string stateLower = stateName.ToLower();
        foreach (var contact in contacts)
        {
            if (contact.State.ToLower() == stateLower)
            {
                foundContacts.Add(contact);
            }
        }
        return foundContacts;
    }


    public List<Contact> CountByCityName(string cityName)
    {
        List<Contact> foundContacts = new List<Contact>();
        string cName = cityName.ToLower();
        foreach (var contact in contacts)
        {
            if (contact.City.ToLower().Equals(cName))
            { foundContacts.Add(contact); }
        }
        return foundContacts;
    }

    public List<Contact> CountByStateName(string stateName)
    {
        List<Contact> foundContacts = new List<Contact>();
        string sName = stateName.ToLower();
        foreach (var contact in contacts)
        {
            if (contact.State.ToLower().Equals(sName))
            {
                foundContacts.Add(contact);
            }
        }
        return foundContacts;
    }
    public void SortContactsByName()
    {
        for (int i = 0; i < contacts.Count - 1; i++)
        {
            for (int j = 0; j < contacts.Count - i - 1; j++)
            {
                if (string.Compare(contacts[j].FirstName, contacts[j + 1].FirstName) > 0)
                {

                    Contact temp = contacts[j];
                    contacts[j] = contacts[j + 1];
                    contacts[j + 1] = temp;
                }
            }
        }
    }
    public void SortContactsByCity()
    {
        for (int i = 0; i < contacts.Count - 1; i++)
        {
            for (int j = 0; j < contacts.Count - i - 1; j++)
            {
                if (string.Compare(contacts[j].City, contacts[j + 1].City) > 0)
                {

                    Contact temp = contacts[j];
                    contacts[j] = contacts[j + 1];
                    contacts[j + 1] = temp;
                }
            }
        }
    }
    public void SortContactsByState()
    {
        for (int i = 0; i < contacts.Count - 1; i++)
        {
            for (int j = 0; j < contacts.Count - i - 1; j++)
            {
                if (string.Compare(contacts[j].State, contacts[j + 1].State) > 0)
                {

                    Contact temp = contacts[j];
                    contacts[j] = contacts[j + 1];
                    contacts[j + 1] = temp;
                }
            }
        }
    }
    public void SortContactsByZip()
    {
        for (int i = 0; i < contacts.Count - 1; i++)
        {
            for (int j = 0; j < contacts.Count - i - 1; j++)
            {
                if (string.Compare(contacts[j].ZipCode, contacts[j + 1].ZipCode) > 0)
                {

                    Contact temp = contacts[j];
                    contacts[j] = contacts[j + 1];
                    contacts[j + 1] = temp;
                }
            }
        }
    }
}