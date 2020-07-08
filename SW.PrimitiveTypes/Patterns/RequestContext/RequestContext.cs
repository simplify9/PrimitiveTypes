using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class RequestContext
    {
        public ClaimsPrincipal User { get; }
        public IReadOnlyCollection<RequestValue> Values { get; }
        public string CorrelationId { get; }
    }
}
