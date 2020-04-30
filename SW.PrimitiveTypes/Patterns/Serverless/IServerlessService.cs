using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IServerlessService
    {
        Task StartAsync(string adapterId, IDictionary<string, string> startupValues = null);
        Task StartAsync(string adapterId, string adapterPath, IDictionary<string, string> startupValues = null);

        Task InvokeVoidAsync(string command, string input = null);
        Task InvokeVoidAsync(string command, int commandTimeout, string input = null);

        Task<TResult> InvokeAsync<TResult>(string command, object input = null);
        Task<TResult> InvokeAsync<TResult>(string command, int commandTimeout, object input = null);
    }
}
