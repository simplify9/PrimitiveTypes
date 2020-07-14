using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface ISearchyHandler : IHandler
    {
        Task<object> Handle(SearchyRequest searchyRequest, bool lookup = false, string searchPhrase = null);
    }

}
