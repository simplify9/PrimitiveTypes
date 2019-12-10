using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SW.PrimitiveTypes
{
    public interface IRequestContext
    {
        ClaimsPrincipal User { get; }
        IReadOnlyCollection<RequestValue> Values { get; }
        string CorrelationId { get; }
        bool IsValid { get; }
    }
}
