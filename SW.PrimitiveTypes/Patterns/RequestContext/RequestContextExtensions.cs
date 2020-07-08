using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SW.PrimitiveTypes
{
    public static class RequestContextExtensions
    {

        public static string GetNameIdentifier(this RequestContext requestContext)
        {
            return requestContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static string GetEntity(this RequestContext requestContext)
        {
            return requestContext.User.FindFirst("Entity")?.Value;
        }

        public static int GetTenant(this RequestContext requestContext)
        {
            int.TryParse(requestContext.User.FindFirst("Tenant")?.Value, out var tenant);
            return tenant;
        }

        public static bool HasGlobalAccess(this RequestContext requestContext)
        {
            return bool.Parse(requestContext.User.FindFirst("GlobalAccess").Value);
        }

        public static IEnumerable<string> GetAllowedEntities(this RequestContext requestContext)
        {
            return requestContext.User.FindAll("AllowedEntity").Select(c => c.Value).Union(new[] { requestContext.User.FindFirst("Entity").Value });
        }
    }
}
