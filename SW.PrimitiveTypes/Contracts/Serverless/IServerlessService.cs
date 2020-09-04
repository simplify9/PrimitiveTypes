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
        Task InvokeAsync(string command, object input, int commandTimeout = 0);
        Task<TResult> InvokeAsync<TResult>(string command, object input, int commandTimeout = 0);
        Task<IDictionary<string, StartupValue>> GetExpectedStartupValues();
    }
}
