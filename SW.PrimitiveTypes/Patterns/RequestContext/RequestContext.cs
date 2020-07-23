using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class RequestContext
    {
        public RequestContext()
        {
        }

        //public RequestContext(ClaimsPrincipal user, IReadOnlyCollection<RequestValue> values, string correlationId)
        //{
        //    User = user;
        //    Values = values;
        //    CorrelationId = correlationId;
        //}

        public void Set(ClaimsPrincipal user, IReadOnlyCollection<RequestValue> values, string correlationId)
        {
            if (IsValid) throw new SWException("Request context already set.");

            User = user;
            Values = values;
            CorrelationId = correlationId;

            IsValid = true;
        }

        public ClaimsPrincipal User { get; private set; }
        public IReadOnlyCollection<RequestValue> Values { get; private set; }
        public string CorrelationId { get; private set; }
        public bool IsValid { get; private set; }
    }
}
