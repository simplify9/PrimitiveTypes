using System;
using System.Linq.Expressions;

namespace SW.PrimitiveTypes
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}
