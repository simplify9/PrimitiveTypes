using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public class RequestContextManager
    {
        private readonly IEnumerable<IRequestContextProvider> requestContextProviders;

        public RequestContextManager(IEnumerable<IRequestContextProvider> requestContextProviders)
        {
            this.requestContextProviders = requestContextProviders;
        }

        async public Task<RequestContext> GetCurrentContext()
        {
            foreach (var provider in requestContextProviders)
            {
                var requestContext = await provider.GetContext();
                if (requestContext != null) return requestContext;
            }

            return null;
        }
    }
}
