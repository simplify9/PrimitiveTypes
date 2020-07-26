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

        public void SetLocale(string locale)
        {
            if (Locale != null) throw new SWException("Locale already set");
            Locale = locale;
        }

        public void SetVersion(string version)
        {
            if (Version != null) throw new SWException("Version already set");
            Version = version;
        }

        public void AddRequestValue(params RequestValue[] values)
        {
            foreach(var val in values) Values.Add(val);
        }

        public void SetUser(ClaimsPrincipal user, ICollection<RequestValue> values, string correlationId)
        {
            if (IsUserValid) throw new SWException("Request context already set.");

            User = user;
            Values = values;
            CorrelationId = correlationId;

            IsUserValid = true;
        }

        public ClaimsPrincipal User { get; private set; }
        public ICollection<RequestValue> Values { get; private set; }
        public string CorrelationId { get; private set; }
        public bool IsUserValid { get; private set; }
        public string Version { get; private set; }
        public string Locale { get; private set; }
    }
}
