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

        public SqlDataReader GetLocations(double minLat, double maxLat, double minLon, double maxLon)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandText = "usp_GetLocations";
            comm.CommandType = System.Data.CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@LAT_MIN", minLat);
            comm.Parameters.AddWithValue("@LAT_MAX", maxLat);
            comm.Parameters.AddWithValue("@LON_MIN", minLon);
            comm.Parameters.AddWithValue("@LON_MAX", maxLon);

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
                                  string createUser)
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

            comm.ExecuteNonQuery();

            return (int)comm.Parameters[0].Value;
        }
    }
}
