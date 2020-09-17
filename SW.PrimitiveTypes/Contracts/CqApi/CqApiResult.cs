using System;
using System.Collections.Generic;

namespace SW.PrimitiveTypes
{
    //public interface IResultWithHeaders 
    //{
    //    IEnumerable<KeyValuePair<string, string>> Headers { get; }
    //    object Result { get; }
    //}

    public class CqApiResult<TResult> : ICqApiResult
    {
        public CqApiResult(TResult result)
        {
            _result = result;
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

        TResult _result;
        public object Result => _result;


        ICollection<KeyValuePair<string, string>> _headers;
        public IEnumerable<KeyValuePair<string, string>> Headers => _headers;

        public CqApiResultStatus Status { get; set; }

        public string ContentType { get; set; }
    }
}
