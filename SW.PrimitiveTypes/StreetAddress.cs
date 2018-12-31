using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class StreetAddress
    {
        public static StreetAddress Empty()
        {
            return new StreetAddress
            {
                //GeoPosition = GeoPosition.Empty()
            };
        }

        public  StreetAddress()
        {
            //GeoPosition = new GeoPosition();
        }
        
        public StreetAddress(string country, string city, string state, string[] street,
            string postCode, string building, string description, string floor,
            string appartment, GeoPosition geoPosition)
        {
            if (geoPosition == null) throw new ArgumentNullException(nameof(geoPosition));

            Country = country;
            City = city;
            State = state;
            Street = street;
            PostCode = postCode;
            Building = building;
            Description = description;
            Floor = floor;
            Appartment = appartment;
            //GeoPosition = geoPosition;
        }

        public string Country { get; set; }

        public string City { get; set; } 

        public string State  { get; set; }

        public string[] Street { get; set; }
        
        public string PostCode { get; set; }

        public string Building { get; set; }

        public string Description { get; set; }

        public string Floor { get; set; }

        public string Appartment { get; set; }

        //public GeoPosition GeoPosition { get; set; } 


    }
}
