using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface ILookupService
    {
        Task<IEnumerable<KeyValuePair<object, string>>> Search(string lookup, string search = null, string filter = null);
        Task<string> Get(string lookup, object key);
        string[] Serves { get; }
    }
}
