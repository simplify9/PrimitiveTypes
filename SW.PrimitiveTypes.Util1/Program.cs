using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes.Util1
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> hashSet = new HashSet<string>();
            foreach (CultureInfo item in CultureInfo.GetCultures(CultureTypes.AllCultures))
                hashSet.Add(item.TwoLetterISOLanguageName);

            foreach (string currency in hashSet)
                Console.WriteLine(currency);

            Console.ReadLine();
        }


    }
}
