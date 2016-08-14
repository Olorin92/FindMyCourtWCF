using FindMyCourt.Rest_Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FindMyCourt
{
    public class FindMyCourtService : IFindMyCourtService
    {
        
        public int CreateUser(Stream user)
        {
            using (StreamReader reader = new StreamReader(user))
            {
                return UserRest.InsertUser(reader.ReadToEnd());
            }
        }

        public Stream GetUser(string pkid)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return UserRest.GetUser(pkid);
        }

        public Stream GetLocations(string minLat, string maxLat, string minLon, string maxLon)
        {
            return LocationRest.GetLocations(minLat, maxLat, minLon, maxLon);
        }

        public int InsertLocation(Stream location)
        {
            using (StreamReader reader = new StreamReader(location))
            {
                return LocationRest.InsertLocation(reader.ReadToEnd());
            }
        }

        public Stream GetLocation(string pkid)
        {
            return LocationRest.GetLocation(pkid);
        }
    }
}
