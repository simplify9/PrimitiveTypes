using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class Audit
    {

        public Audit()
        {
        }

        public DateTime CreatedOn { get; private set; }
        public DateTime ModifiedOn { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }



    }
}
