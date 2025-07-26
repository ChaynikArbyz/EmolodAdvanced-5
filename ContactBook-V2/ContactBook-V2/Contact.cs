using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_V2
{
    internal class Contact
    {
        public string Name;
        public string PhoneNumber;

        public Contact(string name, string phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }
    }
}
