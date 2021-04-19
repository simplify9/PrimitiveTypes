using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class GeoPosition : IEquatable<GeoPosition>
    {
        public bool Equals(GeoPosition other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Longitude == other.Longitude && Latitude == other.Latitude;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GeoPosition) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Longitude.GetHashCode() * 397) ^ Latitude.GetHashCode();
            }
        }

        public static bool operator ==(GeoPosition left, GeoPosition right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GeoPosition left, GeoPosition right)
        {
            return !Equals(left, right);
        }

        public static GeoPosition Empty()
        {
            return new GeoPosition();
        }

        private  GeoPosition()
        {

        }

        public GeoPosition(decimal longitude, decimal latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public decimal? Longitude { get; private set; }
        public decimal? Latitude { get; private set; }

        //public string GeoHash { get; set; }
    }
}
