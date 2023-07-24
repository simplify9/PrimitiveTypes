using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface ICommandHandler<TResult> : IHandler
    {
        Task<TResult> Handle();
    }

    public interface ICommandHandler<in TKey, in TRequest, TResult> : IHandler where TRequest : class
    {
        Task<TResult> Handle(TKey key, TRequest request);
    }
    public interface ICommandHandler<in TRequest, TResult> : IHandler where TRequest : class
    {
        Task<TResult> Handle(TRequest request);
    }

}
