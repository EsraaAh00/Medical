using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Helpers
{
    public class Location
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }

    public static class DistanceHelper
    {
        public static double GetDistance(Location location1, Location location2)
        {
            var R = 6371e3; 
            var lat1 = location1.Latitude.GetValueOrDefault() * Math.PI / 180;
            var lat2 = location2.Latitude.GetValueOrDefault() * Math.PI / 180;
            var deltaLat = (location2.Latitude.GetValueOrDefault() - location1.Latitude.GetValueOrDefault()) * Math.PI / 180;
            var deltaLon = (location2.Longitude.GetValueOrDefault() - location1.Longitude.GetValueOrDefault()) * Math.PI / 180;
            var a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                    Math.Cos(lat1) * Math.Cos(lat2) *
                    Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c; 
        }
    }
}


