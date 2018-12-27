using System;
using System.Collections.Generic;
using System.Text;

namespace SW.Pmm.Primitives
{
    public class Money
    {
        public static Money Empty()
        {
            return new Money();
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

        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
