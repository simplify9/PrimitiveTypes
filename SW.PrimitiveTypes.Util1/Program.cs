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

            int? i = null;

            var i1 = i.Value;

            IHandle<BaseDomainEvent> hanlder = (IHandle<BaseDomainEvent>)(new Event1Hanlder());

            HashSet<string> hashSet = new HashSet<string>();
            foreach (CultureInfo item in CultureInfo.GetCultures(CultureTypes.AllCultures))
                hashSet.Add(item.TwoLetterISOLanguageName);

            foreach (string currency in hashSet)
                Console.WriteLine(currency);

            Console.ReadLine();
        }

        class Event1 : BaseDomainEvent
        {

        }

        class Event1Hanlder : IHandle<Event1>
        {
            public Task Handle(Event1 domainEvent)
            {
                throw new NotImplementedException();
            }
        }


    }
}
