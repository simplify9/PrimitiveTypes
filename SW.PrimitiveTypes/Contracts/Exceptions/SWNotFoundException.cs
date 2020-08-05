using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class SWNotFoundException : SWException
    {
        public SWNotFoundException()
        {
        }

        public SWNotFoundException(string message) : base(message)
        {
        }
    }
}
