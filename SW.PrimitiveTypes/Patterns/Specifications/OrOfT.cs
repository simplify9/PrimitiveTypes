using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class Or<T> : ISpecification<T>
    {
        public Or(ISpecification<T> left, ISpecification<T> right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));

            var e1 = left.Criteria;
            var e2 = right.Criteria;

            // rewrite e1, using the parameter from e2; "&&"
            Criteria = Expression.Lambda<Func<T, bool>>(Expression.OrElse(
                new SwapVisitor(e1.Parameters[0], e2.Parameters[0]).Visit(e1.Body),
                e2.Body), e2.Parameters);
        }

        public Expression<Func<T, bool>> Criteria { get; }
        
    }
}
