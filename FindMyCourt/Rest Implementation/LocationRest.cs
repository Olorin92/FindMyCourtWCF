using FindMyCourtObjectLibrary.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public static Stream GetLocations(string minLat, string maxLat, string minLon, string maxLon, string isLightWeight, string onlyIndoor, string onlyOutdoor)
        {
            List<Location> locations = Location.GetLocations(minLat == null ? (double?)null : Convert.ToDouble(minLat), 
                                                             maxLat == null ? (double?)null : Convert.ToDouble(maxLat), 
                                                             minLon == null ? (double?)null : Convert.ToDouble(minLon), 
                                                             maxLon == null ? (double?)null : Convert.ToDouble(maxLon),
                                                             onlyIndoor == null ? false : Convert.ToBoolean(onlyIndoor),
                                                             onlyOutdoor == null ? false : Convert.ToBoolean(onlyOutdoor));
            string serialization = string.Empty;

            if (isLightWeight != null && Convert.ToBoolean(isLightWeight) == true)
            {
                JArray minifiedLocations = new JArray();

                foreach (Location loc in locations)
                {

                    JObject locJson = new JObject();
                    locJson.Add(nameof(loc.PKID), loc.PKID);
                    locJson.Add(nameof(loc.Name), loc.Name);
                    locJson.Add(nameof(loc.AverageReviewScore), loc.AverageReviewScore);
                    locJson.Add(nameof(loc.NumberOfCourts), loc.NumberOfCourts);
                    locJson.Add(nameof(loc.HasIndoor), loc.HasIndoor);
                    locJson.Add(nameof(loc.HasOutdoor), loc.HasOutdoor);
                    locJson.Add(nameof(loc.Latitude), loc.Latitude);
                    locJson.Add(nameof(loc.Longitude), loc.Longitude);

                    minifiedLocations.Add(locJson);
                }

                serialization = JsonConvert.SerializeObject(minifiedLocations);
            }
            else
            {
                serialization = JsonConvert.SerializeObject(locations);
            }

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