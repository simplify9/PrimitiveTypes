using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class SWValidationException : SWException
    {
        public SWValidationException(IEnumerable<KeyValuePair<string, string>> validations) : 
            base(string.Join(";", validations.Select(i => $"{i.Key}: {i.Value}")))
        {
            Validations = validations;
        }

        public IEnumerable<KeyValuePair<string, string>> Validations { get; set; }
    }
}
