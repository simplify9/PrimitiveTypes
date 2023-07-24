using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IGetHandler<in TKey, TResult> : IHandler
    {
        Task<TResult> Handle(TKey key);
    }

}
