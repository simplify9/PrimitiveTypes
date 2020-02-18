using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class Money
    {
        public static Money Empty()
        {
            return new Money();
        }

        public override bool Equals(object obj)
        {
            return obj is Money money &&
                   Amount == money.Amount &&
                   Currency == money.Currency;
        }

        public override int GetHashCode()
        {
            int hashCode = -259941593;
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Currency);
            return hashCode;
        }

        public  Money() { }

        public Money(decimal amount, string currency)
        {
            if (currency == null)
            {
                throw new ArgumentNullException(nameof(currency));
            }

            Amount = amount;
            Currency = currency;
        }

        public override string ToString()
        {
            return Amount == null ? "[Empty]" : string.Format("{0:0.###}{1}", Amount, Currency);
        }

        public decimal? Amount { get; set; }
        public string Currency { get; set; }


    }
}
