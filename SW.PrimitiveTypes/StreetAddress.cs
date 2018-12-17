using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class StreetAddress
    {
        //public int Id { get; set; }
        public string Country { get; set; }
        //public Country Country { get; set; }
        //public int? CityId { get; set; }
        public string City { get; set; }
        //public string StateName { get; set; }
        public string State  { get; set; }
        public string[] Street { get; set; }
        //public string Line2 { get; set; }
        //public string Line3 { get; set; }
        public string PostCode { get; set; }
        public string Building { get; set; }
        public string Description { get; set; }
        public string Floor { get; set; }
        public string Appartment { get; set; }

        public GeoPosition GeoPosition { get; set; } 


    }
}
