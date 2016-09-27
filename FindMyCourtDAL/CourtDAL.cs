using System;
using System.Collections.Generic;
using System.Data;
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

        public int InsertCourt(string courtName,
                               int locationID,
                               int courtTypeID,
                               int backboardTypeID,
                               bool hasNet,
                               bool hasScoreboard,
                               string createUser)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "usp_InsertCourt";

            comm.Parameters.Add("@PKID", SqlDbType.Int);
            comm.Parameters[0].Direction = ParameterDirection.Output;
            comm.Parameters.AddWithValue("@COURT_NAME", courtName);
            comm.Parameters.AddWithValue("@LOCATION_ID", locationID);
            comm.Parameters.AddWithValue("@COURT_TYPE_ID", courtTypeID);
            comm.Parameters.AddWithValue("@BACKBOARD_TYPE_ID", backboardTypeID);
            comm.Parameters.AddWithValue("@HAS_NET", hasNet);
            comm.Parameters.AddWithValue("@HAS_SCOREBOARD", hasScoreboard);
            comm.Parameters.AddWithValue("@CREATE_USER", createUser);

            comm.ExecuteNonQuery();

            return (int)comm.Parameters["@PKID"].Value;
        }

        public void UpdateCourt(int pkid,
                                string courtName,
                                int locationID,
                                int courtTypeID,
                                int backboardTypeID,
                                bool hasNet,
                                bool hasScoreboard)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "usp_UpdateCourt";

            comm.Parameters.AddWithValue("@PKID", pkid);
            comm.Parameters.AddWithValue("@COURT_NAME", courtName);
            comm.Parameters.AddWithValue("@LOCATION_ID", locationID);
            comm.Parameters.AddWithValue("@COURT_TYPE_ID", courtTypeID);
            comm.Parameters.AddWithValue("@BACKBOARD_TYPE_ID", backboardTypeID);
            comm.Parameters.AddWithValue("@HAS_NET", hasNet);
            comm.Parameters.AddWithValue("@HAS_SCOREBOARD", hasScoreboard);

            comm.ExecuteNonQuery();
        }
    }
}
