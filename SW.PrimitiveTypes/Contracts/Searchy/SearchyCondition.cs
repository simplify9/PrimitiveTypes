using System.Collections.Generic;
using System;
using System.Linq;

namespace SW.PrimitiveTypes
{
    public class SearchyCondition : ICloneable, IEquatable<SearchyCondition>
    {
        public ICollection<SearchyFilter> Filters { get; set; }

        public SearchyCondition() => Filters = new List<SearchyFilter>();

        public SearchyCondition(string field, SearchyRule rule, object value) : this()
        {
            Filters.Add(new SearchyFilter(field, rule, value));
        }

        public SearchyCondition(ISearchyFilter filter)
        {
            Filters = new List<SearchyFilter> { new SearchyFilter(filter) };
        }

        public SearchyCondition(IEnumerable<ISearchyFilter> filters)
        {
            Filters = filters.Select(f => new SearchyFilter(f)).ToList();
        }

        public object Clone()
        {
            return new SearchyCondition
            {
                Filters = Filters.Select(i => (SearchyFilter)i.Clone()).ToList()
            };
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SearchyCondition);
        }

        public bool Equals(SearchyCondition other)
        {
            return other != null &&
                   CollectionComparer<SearchyFilter>.Compare(Filters, other.Filters);
        }

        public override int GetHashCode()
        {
            return -835905588 + EqualityComparer<ICollection<SearchyFilter>>.Default.GetHashCode(Filters);
        }

        public static bool operator ==(SearchyCondition left, SearchyCondition right)
        {
            return EqualityComparer<SearchyCondition>.Default.Equals(left, right);
        }

        public static bool operator !=(SearchyCondition left, SearchyCondition right)
        {
            return !(left == right);
        }

    }
}
