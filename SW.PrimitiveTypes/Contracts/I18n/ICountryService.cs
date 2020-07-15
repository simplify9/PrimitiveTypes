using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public interface ICountryService
    {
        IEnumerable<Country> List();
        Country Get(string CountryCode);
        bool TryGet(string CountryCode, out Country country);

    }
}
