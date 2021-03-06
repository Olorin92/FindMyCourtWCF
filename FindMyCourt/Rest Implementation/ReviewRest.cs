﻿using FindMyCourtObjectLibrary.Objects;
using FindMyCourtObjectLibrary.Proxy_Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace FindMyCourt.Rest_Implementation
{
    public static class ReviewRest
    {
        public static Stream GetCourtReviews(string courtID)
        {
            List<Review> reviews = Review.GetCourtReviews(Convert.ToInt32(courtID));
            string serialization = JsonConvert.SerializeObject(reviews);

            return new MemoryStream(Encoding.UTF8.GetBytes(serialization));
        }

        public static Stream GetLocationReviews(string locationID)
        {
            List<Review> reviews = Review.GetLocationReviews(Convert.ToInt32(locationID));
            string serialization = JsonConvert.SerializeObject(reviews);

            return new MemoryStream(Encoding.UTF8.GetBytes(serialization));
        }

        public static int InsertReview(ProxyReview review)
        {
            Review newReview = JsonConvert.DeserializeObject<Review>(JsonConvert.SerializeObject(review));
            newReview.Save();

            return newReview.PKID;
        }

        public static int UpdateReview(string pkid, ProxyReview review)
        {
            Review existingReview = Review.GetReview(Convert.ToInt32(pkid));
            JsonConvert.PopulateObject(JsonConvert.SerializeObject(review), existingReview);
            existingReview.Save();

            return existingReview.PKID;
        }
    }
}