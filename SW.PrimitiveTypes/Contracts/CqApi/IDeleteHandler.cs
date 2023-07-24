using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{

    public interface IDeleteHandler<in TKey, TResult> : IHandler
    {
        Task<TResult> Handle(TKey key);
    }

}
