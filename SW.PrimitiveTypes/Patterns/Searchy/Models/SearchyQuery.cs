using System.Collections.Generic;
using System.Linq;

namespace SW.PrimitiveTypes
{
    
    public class SearchyQuery
    {
        public ICollection<SearchyCondition> Conditions { get; private set; } = new List<SearchyCondition>();

        public SearchyQuery() {}
        public SearchyQuery(SearchyCondition condition) => Conditions.Add(condition);
        public SearchyQuery(IEnumerable<SearchyCondition> conditions) => Conditions = conditions.ToList();
        public SearchyQuery(SearchyFilter filter) => Conditions.Add(new SearchyCondition(filter));
    }
}
