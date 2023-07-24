using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{

    public interface IQueryHandler<in TKey, in TRequest, TResult> : IHandler where TRequest : class
    {
        Task<TResult> Handle(TKey key, TRequest request);
    }

    public interface IQueryHandler<in TRequest, TResult> : IHandler where TRequest : class
    {
        Task<TResult> Handle(TRequest request);
    }

    public interface IQueryHandler<TResult> : IHandler
    {
        Task<TResult> Handle();
    }
    
    

}
