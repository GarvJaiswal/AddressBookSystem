using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class Contact
    {
        string first_name;
        string last_name;
        string address;
        string city;
        string state;
        int zip;
        int phone_num;
        string email;

        public Contact() { 
        }
        public Contact(string first, string last, string address, string city, string state, int zip, int phone_num, string email)
        {
            first_name = first;
            last_name = last;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phone_num = phone_num;
            this.email = email;
        }

    }
    public class AddressBook
    {
        public Contact record()
        {
            
            Console.WriteLine("Enter first name:");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter address:");
            string addrs = Console.ReadLine();
            Console.WriteLine("Enter city:");
            string cname = Console.ReadLine();
            Console.WriteLine("Enter state name:");
            string state = Console.ReadLine();
            Console.WriteLine("Enter zip code:");
            int zipcode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter phone num:");
            int phone = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();
            Console.ReadLine();

            Contact obj = new Contact(fname,lname,addrs,cname,state,zipcode,phone,email);
            return obj;

        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book");

            List<Contact> list = new List<Contact>();
            AddressBook newRecord= new AddressBook();
            Contact details = new Contact();
            newRecord.record();
            Console.ReadLine();


        }
    }
}
