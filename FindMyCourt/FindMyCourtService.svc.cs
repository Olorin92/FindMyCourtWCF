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

        [return: MessageParameter(Name = "User")]
        public Stream GetUsersFiltered(string email, string username)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return UserRest.GetUser(email, username);
        }

        //public Stream GetUsers()
        //{
        //    WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
        //    return UserRest.GetUsers();
        //}

        public Stream GetLocations(string minLat, string maxLat, string minLon, string maxLon)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
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
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return LocationRest.GetLocation(pkid);
        }

        public Stream GetCourt(string id)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return CourtRest.GetCourt(id);
        }

        public Stream GetCourts(string locationID)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return CourtRest.GetCourts(locationID);
        }

        public int InsertCourt(Stream court)
        {
            using (StreamReader reader = new StreamReader(court))
            {
                return CourtRest.InsertCourt(reader.ReadToEnd());
            }
        }

        public Stream GetLocationReviews(string locationID)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return ReviewRest.GetLocationReviews(locationID);
        }

        public Stream GetCourtReviews(string courtID)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return ReviewRest.GetCourtReviews(courtID);
        }

        public int InsertReview(Stream review)
        {
            using (StreamReader reader = new StreamReader(review))
            {
                return ReviewRest.InsertReview(reader.ReadToEnd());
            }
        }

        public Stream GetCourtTypes()
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return EnumsRest.GetCourtTypes();
        }

        public Stream GetBackboardTypes()
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return EnumsRest.GetBackboardTypes();
        }

        public Stream GetReviewTypes()
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return EnumsRest.GetReviewTypes();
        }
    }
}
