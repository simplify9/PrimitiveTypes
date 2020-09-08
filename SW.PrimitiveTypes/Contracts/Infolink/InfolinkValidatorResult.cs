using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class InfolinkValidatorResult
    {
        private InfolinkValidatorResult()
        {
        }

        public InfolinkValidatorResult(IEnumerable<KeyValuePair<string, string>> validations = null)
        {
            if (validations == null)
                _validations = new List<KeyValuePair<string, string>>();
            else
                _validations = new List<KeyValuePair<string, string>>(validations);
        }

        public void AddError(string code, string text)
        {
            if (code is null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            _validations.Add(new KeyValuePair<string, string>(code, text));
        }

        public bool Success => !_validations.Any();

        ICollection<KeyValuePair<string, string>> _validations;
        public IEnumerable<KeyValuePair<string, string>> Validations
        {
            get
            {
                return _validations;
            }

            private set
            {
                _validations = new List<KeyValuePair<string, string>>(value);
            }
        }
    }
}
