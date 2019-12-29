using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{

    public interface IHandler { }

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

    public interface IGetHandler<in TKey> : IHandler
    {
        Task<object> Handle(TKey key, bool lookup = false);
    }

    public interface IQueryHandler<in TRequest> : IHandler where TRequest : class
    {
        Task<object> Handle(TRequest request);
    }

    public interface IQueryHandler : IHandler 
    {
        Task<object> Handle();
    }

    public interface ISearchyHandler : IHandler
    {
        Task<object> Handle(SearchyRequest searchyRequest, bool lookup = false, string searchPhrase = null);
    }

    public interface IDeleteHandler<in TKey> : IHandler
    {
        Task<object> Handle(TKey key);
    }

}
