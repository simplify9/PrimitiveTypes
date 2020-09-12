using System;
using System.Collections.Generic;

namespace SW.PrimitiveTypes
{
    public interface IResultWithHeaders { }

    public class ResultWithHeaders<TResult> : IResultWithHeaders
    {
        public ResultWithHeaders(TResult result)
        {
            Result = result;
            _headers = new List<KeyValuePair<string, string>>(); 
        }

        public void AddHeader(string name, string value)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _headers.Add(new KeyValuePair<string, string>(name, value));
        }

        public TResult Result { get; private set;}


        ICollection<KeyValuePair<string, string>> _headers;
        public IEnumerable<KeyValuePair<string, string>> Headers => _headers;
    }
}
