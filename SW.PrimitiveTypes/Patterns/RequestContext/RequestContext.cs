using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class RequestContext
    {
        public const string UserHeaderName = "request-context-user";
        public const string ValuesHeaderName = "request-context-values";
        public const string CorrelationIdHeaderName = "request-context-correlation-id";

        private HashSet<RequestValue> values;

        public RequestContext()
        {
            values = new HashSet<RequestValue>();
        }

        public void SetLocale(string locale)
        {
            Locale = locale;
        }

        public void SetVersion(string version)
        {
            Version = version;
        }

        public bool AddValue(RequestValue requestValue)
        {
            return values.Add(requestValue);
        }

        public void Set(ClaimsPrincipal user, IEnumerable<RequestValue> values = null, string correlationId = null)
        {
            if (values != null)
                this.values = new HashSet<RequestValue>(values);

            if (correlationId != null)
                CorrelationId = correlationId;
            else
                CorrelationId = Guid.NewGuid().ToString("N");

            if (user == null || !user.Identity.IsAuthenticated || IsValid)
                return;

            //// allow ONLY ONCE setting of user.
            //if (IsValid)
            //    return;
            //    //throw new SWException("Request context already set.");

            User = user;
            IsValid = true;
        }

        public ClaimsPrincipal User { get; private set; }
        public IReadOnlyCollection<RequestValue> Values => values;
        public string CorrelationId { get; private set; }
        public bool IsValid { get; private set; }
        public string Version { get; private set; }
        public string Locale { get; private set; }

        public string GetValueOf(string name, RequestValueType requestValueType = default)
        {
            var value = values.FirstOrDefault(i =>
                i.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                (requestValueType == default || i.Type == requestValueType));
            return value?.Value;
        }

        //public T GetValueOf<T>(string name, RequestValueType requestValueType = default)
        //{
        //    var value = GetValueOf(name, requestValueType);
        //    if (value is T valueTyped)
        //        return valueTyped;
        //    else
        //        return default;
        //}
    }
}
