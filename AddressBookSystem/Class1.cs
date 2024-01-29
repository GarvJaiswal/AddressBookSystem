using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class Contact
    {
        private string first_name;
        private string last_name;
        private string address;
        private string city;
        private string state;
        private int zip;
        private int PhoneNum;
        private string email;

        public Contact()
        {
        }
        public Contact(string first, string last, string address, string city, string state, int zip, int phone_num, string email)
        {
            first_name = first;
            last_name = last;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.PhoneNum = phone_num;
            this.email = email;
        }

        public string FirstName
        {
            get { return first_name; } // Getter
            set { first_name = value; } // Setter
        }

        public string LastName
        {
            get { return last_name; } // Getter
            set { last_name = value; } // Setter
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

        public int Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        public int PhoneNumber
        {
            get { return PhoneNum; }
            set { PhoneNum = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
