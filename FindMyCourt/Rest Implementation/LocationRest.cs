using FindMyCourtObjectLibrary.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace FindMyCourt.Rest_Implementation
{
    public static class LocationRest
    {
        public static Stream GetLocation(string locationID)
        {
            Location location = Location.GetLocation(Convert.ToInt32(locationID));
            string serialization = JsonConvert.SerializeObject(location);

            return new MemoryStream(Encoding.UTF8.GetBytes(serialization));
        }

        public static Stream GetLocations(string minLat, string maxLat, string minLon, string maxLon)
        {
            List<Location> locations = Location.GetLocations(Convert.ToDouble(minLat), Convert.ToDouble(maxLat), Convert.ToDouble(minLon), Convert.ToDouble(maxLon));
            string serialization = JsonConvert.SerializeObject(locations);

            return new MemoryStream(Encoding.UTF8.GetBytes(serialization));
        }

        public static int InsertLocation(string location)
        {
            Location newLocation = JsonConvert.DeserializeObject<Location>(location);
            newLocation.Save();

            return newLocation.PKID;
        }
    }
}