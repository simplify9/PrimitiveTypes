using System.Collections.Generic;

namespace SW.PrimitiveTypes
{
    public class KeyAndValue
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            return obj is KeyAndValue value &&
                   Key == value.Key &&
                   Value == value.Value;
        }

        public override int GetHashCode()
        {
            int hashCode = 206514262;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Key);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
            return hashCode;
        }
    }
}
