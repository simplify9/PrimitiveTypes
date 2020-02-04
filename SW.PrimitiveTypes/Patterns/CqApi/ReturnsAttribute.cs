using System;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class ReturnsAttribute : Attribute
    {
        public Type Type;
        public int StatusCode;
        public string Conditions;
        public string? Description;
    }
}
