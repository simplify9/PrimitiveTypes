using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class GeoPosition
    {
        public static GeoPosition Empty()
        {
            return new GeoPosition();
        }

        public  GeoPosition()
        {

        }

        public GeoPosition(decimal? longitude, decimal? latitude)
        {
            Longitude = longitude ?? throw new ArgumentNullException(nameof(longitude));
            Latitude = latitude ?? throw new ArgumentNullException(nameof(latitude));
        }

        public decimal? Longitude { get; private set; }
        public decimal? Latitude { get; private set; }

        //public string GeoHash { get; set; }
    }
}
