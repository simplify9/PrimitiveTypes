

using System.Collections.Generic;

namespace SW.PrimitiveTypes
{
    public class SearchyFilterConfig : ISearchyFilterConfig
    {
        public SearchyFilterConfig() => Rules = new List<SearchyRule>();

        public string Type { get; set; }
        public string Text { get; set; }
        public string Field { get; set; }
        public bool Required { get; set; }
        public bool Default { get; set; }
        public ICollection<SearchyRule> Rules { get; set; }
    }
}
