using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IInfolinkReceiver
    {
         Task Initialize();
         Task Finalize();
         Task<object> ListFiles();
         Task<object> GetFile(string fileId);
         Task DeleteFile(string fileId);
    }
}
