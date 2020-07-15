using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface ICommandHandler : IHandler
    {
        Task<object> Handle();
    }

    public interface ICommandHandler<in TKey, in TRequest> : IHandler where TRequest : class
    {
        Task<object> Handle(TKey key, TRequest request);
    }
    public interface ICommandHandler<in TRequest> : IHandler where TRequest : class
    {
        Task<object> Handle(TRequest request);
    }

}
