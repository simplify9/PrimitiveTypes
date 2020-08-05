using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class SWUnauthorizedException : SWException
    {
        public SWUnauthorizedException()
        {
        }

        public SWUnauthorizedException(string message) : base(message)
        {
        }
    }



}
