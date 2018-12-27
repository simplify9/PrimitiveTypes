using System;
using System.Collections.Generic;
using System.Text;

namespace SW.Pmm.Primitives
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

        public string Name { get; private set; }
        public PhoneNo[] Phones { get; private set; }
        public Email[] Emails { get; private set; }
    }
}
