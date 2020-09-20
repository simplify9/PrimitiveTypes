using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class CollectionComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public static bool Compare(IEnumerable<T> x, IEnumerable<T> y)
        {
            return new CollectionComparer<T>().Equals(x, y);
        }

        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            if (x == null && y != null) return false;
            if (x != null && y == null) return false;
            if (x == null && y == null) return true;
            return x.SequenceEqual(y);  
        }

        public int GetHashCode(IEnumerable<T> obj)
        {
            throw new NotImplementedException();
        }
    }
}
