using System;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IListenGenericBase { }
    public interface IListen<TMessage> : IListenGenericBase where TMessage : class
    {
        Task Process(TMessage message);
        Task OnFail(Exception ex) => Task.CompletedTask;
    } 
}
