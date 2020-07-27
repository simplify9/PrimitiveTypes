﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class RequestContext
    {
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
            if (IsValid) throw new SWException("Request context already set.");

            User = user;
            if (values != null) this.values = new HashSet<RequestValue>(values);
            if (correlationId != null) CorrelationId = correlationId;

            IsValid = true;
        }

        public ClaimsPrincipal User { get; private set; }

        public IReadOnlyCollection<RequestValue> Values
        {
            get
            {
                return values;
            }
        }

        public string CorrelationId { get; private set; }
        public bool IsValid { get; private set; }
        public string Version { get; private set; }
        public string Locale { get; private set; }
    }
}
