using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IGetHandler<in TKey> : IHandler
    {
        Task<object> Handle(TKey key, bool lookup = false);
    }

}
