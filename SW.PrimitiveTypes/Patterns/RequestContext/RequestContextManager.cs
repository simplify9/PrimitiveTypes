using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class RequestContextManager
    {
        private readonly IEnumerable<IRequestContext> requestContexts;

        public RequestContextManager(IEnumerable<IRequestContext> requestContexts)
        {
            this.requestContexts = requestContexts;
        }

        public IRequestContext Current => requestContexts.Where(e => e.IsValid).SingleOrDefault();

    }
}
