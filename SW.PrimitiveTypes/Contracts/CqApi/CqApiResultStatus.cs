﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public enum CqApiResultStatus
    {
        Ok = 0,
        UnderProcessing = 1,
        ChangedLocation = 11,
        Error = 100,
    }
}
