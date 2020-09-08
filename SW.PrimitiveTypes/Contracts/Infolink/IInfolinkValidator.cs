using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public interface IInfolinkValidator
    {
        Task<InfolinkValidatorResult> Validate(XchangeFile xchangeFile);
    }
}
