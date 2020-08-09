
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public static object GetFromQueryString(Type type, IQueryCollection queryCollection)
        {
            try
            {
                var obj = Activator.CreateInstance(type);
                var properties = type.GetProperties();
                foreach (var property in properties)
                {
                    object value = null;
                    Type propType = property.PropertyType;
                    if (propType.IsInterface)
                        throw new SWException($"Type of {property.Name} is an interface. If it's a collection type, consider using List<> or an array.");

                    var queries = queryCollection[property.Name];

                    bool isEnumerable = property.PropertyType.GetInterface(nameof(IEnumerable)) != null;

                    if (isEnumerable)
                    {
                        Type nested = propType.GetElementType() ?? propType.GetGenericArguments()[0];
                        Array tmp = Array.CreateInstance(nested, queries.Count);

                        var queryObjects = queries.Select(q => q.ConvertValueToType(nested));
                        for (int i = 0; i < queries.Count; i++)
                            tmp.SetValue(queryObjects.ElementAt(i), i);

                        Type listType = propType.IsInterface ? typeof(List<object>) : propType;
                        bool isArray = propType.IsArray;
                        value = isArray ? tmp : Activator.CreateInstance(listType, new object[] { new object[] { tmp } });
                    }
                    else
                    {
                        value = queries.FirstOrDefault()
                                .ConvertValueToType(propType);
                    }

                    if (value == null)
                        continue;

                    property.SetValue(obj, value, null);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new SWException($"Error constructing type: '{type.Name}' from parameters. {ex.Message}");

            }

        }

        public static string ToQueryString<T>(this T obj) where T : class
        {
            string[] props = typeof(T).GetProperties()
                .Select(property => {

                    bool isEnumerable = property.PropertyType.GetInterface(nameof(IEnumerable)) != null;
                    if (isEnumerable)
                    {
                        IEnumerable tmp = ((IEnumerable)property.GetValue(obj).ConvertValueToType(property.PropertyType));
                        IEnumerable<string> enumerable = tmp.Cast<string>();

                        Type nested = property.PropertyType.GetElementType() ?? property.PropertyType.GetGenericArguments()[0];

                        int length = 0;
                        foreach (var val in tmp) ++length;

                        Array array = Array.CreateInstance(nested, length);

                        int counter = 0;
                        foreach (var val in tmp)
                        {
                            array.SetValue(val, counter);
                            ++counter;
                        }

                        string q = string.Empty;
                        for (int i = 0; i < array.Length - 1; i++) q += $"{property.Name}={array.GetValue(i)}&";
                        q += $"{property.Name}={array.GetValue(array.Length - 1)}";

                        return q;
                    }
                    else return $"{property.Name}={property.GetValue(obj)}";
                })
                .ToArray();

            string queryString = string.Empty;
            for (int i = 0; i < props.Count() - 1; i++) queryString += props[i] + '&';
            queryString += props[props.Length - 1];

            return queryString;
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
