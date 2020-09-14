using System.Collections.Generic;
using System.Linq;

namespace SW.PrimitiveTypes
{
    public class SWValidationException : SWException
    {
        public SWValidationException(IEnumerable<KeyValuePair<string, string>> validations) : 
            base(string.Join(";", validations.Select(i => $"{i.Key}: {i.Value}")))
        {
            Validations = validations;
        }

        public SWValidationException(string key, string value) :
            base($"{key}: {value}")
        {
            var validations = new List<KeyValuePair<string, string>>();
            validations.Add(new KeyValuePair<string, string>(key, value));
            Validations = validations;
        }

        public IEnumerable<KeyValuePair<string, string>> Validations { get; set; }
    }
}
