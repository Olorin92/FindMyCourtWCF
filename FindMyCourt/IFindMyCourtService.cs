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



        #endregion
    }
}
