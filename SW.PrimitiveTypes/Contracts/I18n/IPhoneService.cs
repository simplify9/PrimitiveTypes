using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public interface IPhoneService
    {
        PhoneValidationResponse Validate(string phone, string countryCode = null);
    }
}
