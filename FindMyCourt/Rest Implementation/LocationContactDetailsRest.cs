﻿using FindMyCourtObjectLibrary.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace FindMyCourt.Rest_Implementation
{
    public static class LocationContactDetailsRest
    {
        public static Stream GetLocationContactDetails(string locationID)
        {
            LocationContactDetails contactDetails = LocationContactDetails.GetLocationContactDetails(Convert.ToInt32(locationID));
            string serialization = JsonConvert.SerializeObject(contactDetails);

            return new MemoryStream(Encoding.UTF8.GetBytes(serialization));
        }

        public static int InsertLocationContactDetails(string contactDetails)
        {
            LocationContactDetails newContactDetails = JsonConvert.DeserializeObject<LocationContactDetails>(contactDetails);
            newContactDetails.Save();

            return newContactDetails.PKID;
        }
    }
}