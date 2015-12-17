using System;
using System.Xml.Schema;

namespace _05_Other_Types
{
    public struct Location
    {
        private double latitude;
        private double longitude;
        private Planet planet;

        public Location(double latitude, double longitude, Planet planet) 
            :this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public Planet Planet
        {
            get { return this.planet; }
            set
            {
                this.planet = value;
            }
        }

        public double Latitude
        {
            get { return this.latitude; }
            set
            {
                if (value < -90 ||value> 90)
                {
                    throw new ArgumentOutOfRangeException("Latitude must be between -90 and 90 degrees.");
                }
                this.latitude = value;
            }
            
        }

        public double Longitude
        {
            get
            {
                return this.longitude;
            }
            set
            {
                if (value < 0 || value > 180)
                {
                    throw new ArgumentOutOfRangeException("Longitude must be between 0 and 180 degrees.");
                }
                this.longitude = value;
            }
            
        }

        public override string ToString()
        {
            return $"{this.Latitude}, {this.Longitude} - {this.Planet}";
        }
    }
}