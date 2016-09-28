using FindMyCourt.Rest_Implementation;
using FindMyCourtObjectLibrary.Common;
using FindMyCourtObjectLibrary.Objects;
using FindMyCourtObjectLibrary.Proxy_Objects;
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

        public int CreateUser(ProxyUser user)
        {
            return UserRest.InsertUser(user);
        }

        public ProxyUser GetUser(string pkid)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return UserRest.GetUser(pkid);
        }

        [return: MessageParameter(Name = "User")]
        public Stream GetUsersFiltered(string email, string username)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return UserRest.GetUsers(email, username);
        }

        //public Stream GetUsers()
        //{
        //    WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
        //    return UserRest.GetUsers();
        //}

        public Stream GetLocations(string minLat, string maxLat, string minLon, string maxLon, string isLightWeight, string onlyIndoor, string onlyOutdoor)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return LocationRest.GetLocations(minLat, maxLat, minLon, maxLon, isLightWeight, onlyIndoor, onlyOutdoor);
        }

        public int InsertLocation(ProxyLocation location)
        {
            return LocationRest.InsertLocation(location);
        }

        public Stream GetLocation(string pkid)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return LocationRest.GetLocation(pkid);
        }

        public Stream GetLocationContactDetails(string locationID)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return LocationContactDetailsRest.GetLocationContactDetails(locationID);
        }

        public int InsertLocationContactDetails(ProxyLocationContactDetails locationContactDetails)
        {
            return LocationContactDetailsRest.InsertLocationContactDetails(locationContactDetails);
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

        public int InsertCourt(ProxyCourt court)
        {
            return CourtRest.InsertCourt(court);
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

        public int InsertReview(ProxyReview review)
        {
            return ReviewRest.InsertReview(review);
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

        //public Stream Login()
        //{
        //    string username = WebOperationContext.Current.IncomingRequest.Headers["username"];
        //    string password = WebOperationContext.Current.IncomingRequest.Headers["password"];

        //    if ((username == null || username == string.Empty) || (password == null || password == string.Empty))
        //    {
        //        throw new WebException("You must provide both a username and a password to login");
        //    }
        //    else
        //    {
        //        User user = User.GetUsers(null, username)[0];
        //        string saltedPassword = SaltedPasswordUtility.GenerateSaltedPassword(user.Salt, password);

        //        if (saltedPassword == user.SaltedPassword)
        //        {
        //            return UserRest.GetUser(user.PKID.ToString());
        //        }
        //        else
        //        {
        //            throw new WebException("Invalid credentials");
        //        }
        //    }
        //}

        [return: MessageParameter(Name = "PKID")]
        public int UpdateUser(string pkid, ProxyUser user)
        {
            return UserRest.UpdateUser(pkid, user);
        }

        [return: MessageParameter(Name = "PKID")]
        public int UpdateLocation(string pkid, ProxyLocation location)
        {
            return LocationRest.UpdateLocation(pkid, location);
        }

        [return: MessageParameter(Name = "PKID")]
        public int UpdateLocationContactDetails(string pkid, ProxyLocationContactDetails locationContactDetails)
        {
            return LocationContactDetailsRest.UpdateLocationContactDetails(pkid, locationContactDetails);
        }

        [return: MessageParameter(Name = "PKID")]
        public int UpdateCourt(string pkid, ProxyCourt court)
        {
            return CourtRest.UpdateCourt(pkid, court);
        }

        [return: MessageParameter(Name = "PKID")]
        public int UpdateReview(string pkid, ProxyReview review)
        {
            return ReviewRest.UpdateReview(pkid, review);
        }
    }
}
