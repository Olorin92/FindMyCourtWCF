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
        [WebInvoke(UriTemplate = "Locations?minLat={minLat}&maxLat={maxLat}&minLon={minLon}&maxLon={maxLon}",
           Method = "GET")]
        [return: MessageParameter(Name = "Locations")]
        Stream GetLocations(string minLat, string maxLat, string minLon, string maxLon);

        [OperationContract]
        [WebInvoke(UriTemplate = "Locations",
            Method = "POST")]
        [return: MessageParameter(Name = "PKID")]
        int InsertLocation(Stream location);
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

        #endregion
    }
}
