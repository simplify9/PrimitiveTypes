using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IRequestContextProvider
    {
        //ClaimsPrincipal User { get; }
        //IReadOnlyCollection<RequestValue> Values { get; }
        //string Name { get; }
        //bool IsValid { get; }

        //Task<ClaimsPrincipal> GetUser();
        //Task<IReadOnlyCollection<RequestValue>> GetValues();
        //Task<string> GetCorrelationId();
        //Task<bool> GetIsValid();

        Task<RequestContext> GetContext();


    }
}
