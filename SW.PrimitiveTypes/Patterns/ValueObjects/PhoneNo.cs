using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class PhoneNo
    {
        public static PhoneNo Empty()
        {
            return new PhoneNo { };
        }

        protected PhoneNo() { }

        public static bool IsValidFormat(string number)
        {
            if (number == null) throw new ArgumentNullException(nameof(number));

            return true;
        }

        public PhoneNo(string number)
        {
            if (number == null) throw new ArgumentNullException(nameof(number));

            if (!IsValidFormat(number))
            {
                throw new ArgumentException(
                    string.Format("Provided value '{0}' is not a correct phone format", number), nameof(number));
            }

            Value = number;
        }

        public PhoneNo(PhoneNo another)
        {
            if (another == null) throw new ArgumentNullException(nameof(another));
            Value = another.Value;
        }

        public string Value { get; private set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
