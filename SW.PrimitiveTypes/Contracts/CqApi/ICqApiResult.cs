using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public interface ICqApiResult
    {
        CqApiResultStatus Status { get; }
        IEnumerable<KeyValuePair<string, string>> Headers { get; }
        string ContentType { get; }
        object Result { get; }
    }
}
