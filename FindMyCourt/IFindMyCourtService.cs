using FindMyCourtObjectLibrary.Proxy_Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FindMyCourt
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFindMyCourtService" in both code and config file together.
    [ServiceContract]
    public interface IFindMyCourtService
    {
        #region UserMethods

        [OperationContract]
        [WebInvoke(UriTemplate = "Users",
            Method = "POST")]
        [return: MessageParameter(Name = "PKID")]
        int CreateUser(Stream user);

        [OperationContract]
        [WebInvoke(UriTemplate = "Users/{pkid}",
            Method = "PUT",
            BodyStyle = WebMessageBodyStyle.Bare)]
        [return: MessageParameter(Name = "PKID")]
        int UpdateUser(string pkid, ProxyUser user);

        [OperationContract]
        [WebInvoke(UriTemplate = "Users/{pkid}",
            Method = "GET")]
        [return: MessageParameter(Name = "User")]
        Stream GetUser(string pkid);

        [OperationContract]
        [WebInvoke(UriTemplate = "Users?email={email}&username={username}",
            Method = "GET")]
        [return: MessageParameter(Name = "User")]
        Stream GetUsersFiltered(string email, string username);

        //[OperationContract]
        //[WebInvoke(UriTemplate = "Users",
        //    Method = "GET")]
        //[return: MessageParameter(Name = "User")]
        //Stream GetUsers();

        #endregion

        #region LocationMethods

        [OperationContract]
        [WebInvoke(UriTemplate = "Locations/{locationID}",
           Method = "GET")]
        [return: MessageParameter(Name = "Location")]
        Stream GetLocation(string locationID);

        [OperationContract]
        [WebInvoke(UriTemplate = "Locations?minLat={minLat}&maxLat={maxLat}&minLon={minLon}&maxLon={maxLon}&isLightweight={isLightweight}&onlyIndoor={onlyIndoor}&onlyOutdoor={onlyOutdoor}",
           Method = "GET")]
        [return: MessageParameter(Name = "Locations")]
        Stream GetLocations(string minLat, string maxLat, string minLon, string maxLon, string isLightWeight, string onlyIndoor, string onlyOutdoor);

        [OperationContract]
        [WebInvoke(UriTemplate = "Locations",
            Method = "POST")]
        [return: MessageParameter(Name = "PKID")]
        int InsertLocation(Stream location);

        [OperationContract]
        [WebInvoke(UriTemplate = "Locations/{pkid}",
            Method = "PUT",
            BodyStyle = WebMessageBodyStyle.Bare)]
        [return: MessageParameter(Name = "PKID")]
        int UpdateLocation(string pkid, ProxyLocation location);

        [OperationContract]
        [WebInvoke(UriTemplate = "Locations/{locationID}/ContactDetails",
            Method = "GET")]
        [return: MessageParameter(Name = "CpntactDetails")]
        Stream GetLocationContactDetails(string locationID);

        [OperationContract]
        [WebInvoke(UriTemplate = "LocationContactDetails",
            Method = "POST")]
        [return: MessageParameter(Name = "PKID")]
        int InsertLocationContactDetails(Stream locationContactDetails);

        [OperationContract]
        [WebInvoke(UriTemplate = "LocationContactDetails/{pkid}",
            Method = "PUT",
            BodyStyle = WebMessageBodyStyle.Bare)]
        [return: MessageParameter(Name = "PKID")]
        int UpdateLocationContactDetails(string pkid, ProxyLocationContactDetails locationContactDetails);
        #endregion

        #region CourtMethods

        [OperationContract]
        [WebInvoke(UriTemplate = "Courts/{id}",
            Method = "GET")]
        [return: MessageParameter(Name = "Court")]
        Stream GetCourt(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "Locations/{locationID}/Courts",
            Method = "GET")]
        [return: MessageParameter(Name = "Courts")]
        Stream GetCourts(string locationID);

        [OperationContract]
        [WebInvoke(UriTemplate = "Courts",
            Method = "POST")]
        [return: MessageParameter(Name = "PKID")]
        int InsertCourt(Stream court);

        [OperationContract]
        [WebInvoke(UriTemplate = "Courts/{pkid}",
            Method = "PUT",
            BodyStyle = WebMessageBodyStyle.Bare)]
        [return: MessageParameter(Name = "PKID")]
        int UpdateCourt(string pkid, ProxyCourt court);

        #endregion

        #region Review Methods

        [OperationContract]
        [WebInvoke(UriTemplate = "Locations/{locationID}/Reviews",
            Method = "GET")]
        [return: MessageParameter(Name = "Reviews")]
        Stream GetLocationReviews(string locationID);

        [OperationContract]
        [WebInvoke(UriTemplate = "Courts/{courtID}/Reviews",
            Method = "GET")]
        [return: MessageParameter(Name = "Reviews")]
        Stream GetCourtReviews(string courtID);

        [OperationContract]
        [WebInvoke(UriTemplate = "Reviews",
            Method = "POST")]
        [return: MessageParameter(Name = "PKID")]
        int InsertReview(Stream review);

        [OperationContract]
        [WebInvoke(UriTemplate = "Reviews/{pkid}",
            Method = "PUT",
            BodyStyle = WebMessageBodyStyle.Bare)]
        [return: MessageParameter(Name = "PKID")]
        int UpdateReview(string pkid, ProxyReview review);

        #endregion

        #region Enum Methods

        [OperationContract]
        [WebInvoke(UriTemplate = "CourtTypes",
            Method = "GET")]
        [return: MessageParameter(Name = "CourtTypes")]
        Stream GetCourtTypes();

        [OperationContract]
        [WebInvoke(UriTemplate = "BackboardTypes",
            Method = "GET")]
        [return: MessageParameter(Name = "BackboardTypes")]
        Stream GetBackboardTypes();

        [OperationContract]
        [WebInvoke(UriTemplate = "ReviewTypes",
            Method = "GET")]
        [return: MessageParameter(Name = "ReviewTypes")]
        Stream GetReviewTypes();

        #endregion

        #region Auth Methods

        [OperationContract]
        [WebInvoke(UriTemplate = "Login",
            Method = "GET")]
        Stream Login();

        #endregion
    }
}
