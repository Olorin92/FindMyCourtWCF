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
    public static class CourtRest
    {
        public static Stream GetCourt(string id)
        {
            Court court = Court.GetCourt(Convert.ToInt32(id));
            string serialization = JsonConvert.SerializeObject(court);

            return new MemoryStream(Encoding.UTF8.GetBytes(serialization));
        }

        public static Stream GetCourts(string locationID)
        {
            List<Court> courts = Court.GetCourts(Convert.ToInt32(locationID));
            string serialization = JsonConvert.SerializeObject(courts);

            return new MemoryStream(Encoding.UTF8.GetBytes(serialization));
        }

        public static int InsertCourt(string court)
        {
            Court newCourt = JsonConvert.DeserializeObject<Court>(court);
            newCourt.Save();

            return newCourt.PKID;
        }

        public static int UpdateCourt(string pkid, Court court)
        {
            Court existingCourt = Court.GetCourt(Convert.ToInt32(pkid));
            JsonConvert.PopulateObject(JsonConvert.SerializeObject(court), existingCourt);
            existingCourt.Save();

            return existingCourt.PKID;
        }
    }
}