
using System;

namespace SW.PrimitiveTypes
{
    public static class ObjectExtensions
    {

        private static Type GetNullableType(Type type)
        {
            if (type == typeof(string)) return typeof(string);
            if (type == typeof(object)) return typeof(object);
            return Nullable.GetUnderlyingType(type);
        }


        public static object ConvertValueToType(this object value, Type type)
        {

            bool typeNullable = (GetNullableType(type) == null) ? false : true;

            if (value is null && typeNullable) return null;

            else if (value is null) return Activator.CreateInstance(type);

            if (value.GetType() == type) return value;
            if (type.IsAssignableFrom(value.GetType())) return value;

            var nakedType = GetNullableType(type);
            if (nakedType != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString())) return null;

                if (nakedType.IsEnum) return Enum.Parse(nakedType, value.ToString(), true);
                return Convert.ChangeType(value, nakedType);
            }

            if (type.IsEnum) return Enum.Parse(type, value.ToString(), true);
            return Convert.ChangeType(value, type);
        }
    }
}
