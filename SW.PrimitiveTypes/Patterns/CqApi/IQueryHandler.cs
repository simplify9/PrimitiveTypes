using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IQueryHandler<in TKey, in TRequest> : IHandler where TRequest : class
    {
        Task<object> Handle(TKey key, TRequest request);
    }

    public interface IQueryHandler<in TRequest> : IHandler where TRequest : class
    {
        Task<object> Handle(TRequest request);
    }

    public interface IQueryHandler : IHandler
    {
        Task<object> Handle();
    }

}
