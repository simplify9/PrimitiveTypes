using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IInfolinkHandler
    {
        Task<XchangeFile> Handle(XchangeFile xchangeFile);
    }
}
