using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtDAL
{
    public class CourtDAL : BaseDAL
    {
        public CourtDAL(string environmentName) : base(environmentName)
        {
            
        }

        public SqlDataReader GetCourt(int pkid)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandText = "usp_GetCourt";
            comm.CommandType = System.Data.CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@PKID", pkid);

            return comm.ExecuteReader();
        }

        public SqlDataReader GetCourts(int locationID)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandText = "usp_GetCourts";
            comm.CommandType = System.Data.CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@LOCATION_ID", locationID);

            return comm.ExecuteReader();
        }
    }
}
