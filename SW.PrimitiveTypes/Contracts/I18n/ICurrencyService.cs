using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface ICurrencyService
    {
        IEnumerable<Currency> List();
        Currency Get(string currency);
        bool TryGet(string currency, out Currency country);
        Task<decimal> ConvertAsync(decimal value, string fromCurrency, string toCurrency);

    }
}
