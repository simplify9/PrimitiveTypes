using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class Contact
    {
        public static Contact Empty()
        {
            return new Contact();
        }

        public Contact()
        {

        }

        public Contact(string name, PhoneNo[] phones, Email[] emails)
        {
            if (phones == null) throw new ArgumentNullException(nameof(phones));
            if (emails == null) throw new ArgumentNullException(nameof(emails));

            Name = name;
            Phones = phones;
            Emails = emails;
        }

        public string Name { get;  set; }
        public PhoneNo[] Phones { get;  set; }
        public Email[] Emails { get;  set; }
    }
}
