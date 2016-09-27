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

        public static int InsertReview(string review)
        {
            Review newReview = JsonConvert.DeserializeObject<Review>(review);
            newReview.Save();

            return newReview.PKID;
        }

        public static int UpdateReview(string pkid, string review)
        {
            Review existingReview = Review.GetReview(Convert.ToInt32(pkid));
            JsonConvert.PopulateObject(review, existingReview);
            existingReview.Save();

            return existingReview.PKID;
        }
    }
}