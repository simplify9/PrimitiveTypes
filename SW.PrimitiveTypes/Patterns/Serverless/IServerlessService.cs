using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IServerlessService
    {
        Task StartAsync(string adapterId, string[] arguments = null);
        Task InvokeVoidAsync(string command, string input = null);
        Task<string> InvokeAsync(string command, string input = null);
    }
}
