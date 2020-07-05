using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public static class IRepositoryExtensions
    {
        public static async Task<T> FirstOrDefault<T>(this IRepository r, ISpecification<T> spec)
            where T: BaseEntity
        {
            var list = await r.List(spec);
            return list.FirstOrDefault();
        }
    }
}
