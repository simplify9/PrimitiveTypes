using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class All<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria => (o) => true;
    }
}
