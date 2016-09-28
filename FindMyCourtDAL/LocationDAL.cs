using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtDAL
{
    public class LocationDAL : BaseDAL
    {

        public LocationDAL(string environmentName)
            : base(environmentName)
        {

        }

        public SqlDataReader GetLocations(double? minLat, double? maxLat, double? minLon, double? maxLon, bool onlyIndoor, bool onlyOutdoor)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandText = "usp_GetLocations";
            comm.CommandType = System.Data.CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@LAT_MIN", minLat);
            comm.Parameters.AddWithValue("@LAT_MAX", maxLat);
            comm.Parameters.AddWithValue("@LON_MIN", minLon);
            comm.Parameters.AddWithValue("@LON_MAX", maxLon);
            comm.Parameters.AddWithValue("@ONLY_INDOOR", onlyIndoor);
            comm.Parameters.AddWithValue("@ONLY_OUTDOOR", onlyOutdoor);

            return comm.ExecuteReader();
        }

        public SqlDataReader GetLocation(int locationID)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandText = "usp_GetLocation";
            comm.CommandType = System.Data.CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@LOCATION_ID", locationID);

            return comm.ExecuteReader();
        }

        public int InsertLocation(string name,
                                  double longitude,
                                  double latitude,
                                  string createUser,
                                  string locationDescription)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandText = "usp_InsertLocation";
            comm.CommandType = System.Data.CommandType.StoredProcedure;

            comm.Parameters.Add("@PKID", System.Data.SqlDbType.Int);
            comm.Parameters[0].Direction = System.Data.ParameterDirection.Output;
            comm.Parameters.AddWithValue("@LOCATION_NAME", name);
            comm.Parameters.AddWithValue("@LONGITUDE", longitude);
            comm.Parameters.AddWithValue("@LATITUDE", latitude);
            comm.Parameters.AddWithValue("@CREATE_USER", createUser);
            comm.Parameters.AddWithValue("@LOCATION_DESCRIPTION", locationDescription);

            comm.ExecuteNonQuery();

            return (int)comm.Parameters[0].Value;
        }

        public void UpdateLocation(int pkid,
                                   string name,
                                   double longitude,
                                   double latitude,
                                   string locationDescription)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandText = "usp_UpdateLocation";
            comm.CommandType = System.Data.CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@PKID", pkid);
            comm.Parameters.AddWithValue("@LOCATION_NAME", name);
            comm.Parameters.AddWithValue("@LONGITUDE", longitude);
            comm.Parameters.AddWithValue("@LATITUDE", latitude);
            comm.Parameters.AddWithValue("@LOCATION_DESCRIPTION", locationDescription);

            comm.ExecuteNonQuery();
        }
    }
}
