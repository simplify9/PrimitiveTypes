using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class Email
    {
        public string Value { get; private set; }

        public static Email Empty()
        {
            return new Email { };
        }

        public  Email()
        {

        }

        public static bool IsValidFormat(string email)
        {
            if (email == null) throw new ArgumentNullException(nameof(email));

            return true;
        }

        public Email(Email another)
        {
            if (another == null) throw new ArgumentNullException(nameof(another));

            Value = another.Value;
        }

        public Email(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (!IsValidFormat(value))
            {
                throw new ArgumentException(
                    string.Format("Provided value '{0}' is not a correct e-mail format", value), nameof(value));
            }

            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
