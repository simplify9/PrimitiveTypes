using System.Collections.Generic;

namespace SW.PrimitiveTypes
{
    public class Country
    {
        public Country()
        {
        }

        public Country(string Values)
        {

            var values = Values.Split(';');
            Code = values[0];
            IsoCode = values[1];
            IsoNumber = short.Parse( values[2]);
            Name = values[3];
            Capital = values[4];
            Languages = values[5];
            PostCodeFormat = values[6];
            PostCodeRegex = values[7];
            Phone = values[8];
            CurrencyCode = values[9];
            CurrencyName = values[10];
            Tld = values[11];
        }

        public string Tld { get; set; }
        public string Phone { get; set; }
        public string PostCodeFormat { get; set; }
        public string PostCodeRegex { get; set; }
        public string Languages { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public short IsoNumber { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string Capital { get; set; }

        public override string ToString()
        {
            return $"{Code};{IsoCode};{IsoNumber};{Name};{Capital};{Languages};{PostCodeFormat};{PostCodeRegex};{Phone};{CurrencyCode};{CurrencyName};{Tld}";
        }
    }
}
