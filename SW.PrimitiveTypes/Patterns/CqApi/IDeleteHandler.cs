using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IDeleteHandler<in TKey> : IHandler
    {
        Task<object> Handle(TKey key);
    }

}
