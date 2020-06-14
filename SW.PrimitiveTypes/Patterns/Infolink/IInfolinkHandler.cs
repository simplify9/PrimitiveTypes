using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IInfolinkHandler
    {
        Task<object> Handle(XchangeFile xchangeFile);
    }
}
