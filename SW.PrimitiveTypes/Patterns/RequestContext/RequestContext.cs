using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class RequestContext
    {
        public RequestContext(ClaimsPrincipal user, IReadOnlyCollection<RequestValue> values, string correlationId)
        {
            User = user;
            Values = values;
            CorrelationId = correlationId;
        }

        public ClaimsPrincipal User { get; }
        public IReadOnlyCollection<RequestValue> Values { get; }
        public string CorrelationId { get; }
    }
}
