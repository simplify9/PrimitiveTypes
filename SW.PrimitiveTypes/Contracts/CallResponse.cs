using System;

namespace SW.PrimitiveTypes
{
    [Obsolete]
    public class CallResponse
    {
        public string Description = "";

        public bool Result;

        public int Status;

        public string AdditionalData = "";



        public CallResponse()
        {
        }

        public CallResponse(bool Result)
        {
            this.Result = Result;
        }

        public CallResponse(bool Result, string Description) : this(Result)
        {
            this.Description = Description;
        }

        public CallResponse(bool Result, int Status, string Description) : this(Result, Description)
        {
            this.Status = Status;
        }

        public CallResponse(bool Result, int Status, string Description, string AdditionalData) : this(Result, Status, Description)
        {
            this.AdditionalData = AdditionalData;
        }
    }

    [Obsolete]
    public class CallResponse<T>
    {
        public string Description = "";

        public bool Result;

        public int Status;

        public string AdditionalData = "";

        public T ResultObject;

        public CallResponse()
        {
        }

        public CallResponse(bool Result, int Status = 0, string Description = "", string AdditionalData = "", T ResultObject = default(T))
        {
            this.Result = Result;
            this.Status = Status;
            this.Description = Description;
            this.AdditionalData = AdditionalData;
            this.ResultObject = ResultObject;
        }
    }
}
