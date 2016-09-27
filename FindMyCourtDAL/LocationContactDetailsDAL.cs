using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtDAL
{
    public class LocationContactDetailsDAL : BaseDAL
    {
        public LocationContactDetailsDAL(string environmentName) : base(environmentName)
        {
        }

        public SqlDataReader GetLocationContactDetails(int locationID)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "usp_GetLocationContactDetails";

            comm.Parameters.AddWithValue("@PKID", locationID);

            return comm.ExecuteReader();
        }

        public int InsertLocationContactDetails(string contactName,
                                                string mobile,
                                                string phone,
                                                string website)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "usp_InsertLocationContactDetails";

            comm.Parameters.Add("@PKID", SqlDbType.Int);
            comm.Parameters[0].Direction = ParameterDirection.Output;
            comm.Parameters.AddWithValue("@LOCATION_CONTACT_NAME", contactName);
            comm.Parameters.AddWithValue("@LOCATION_CONTACT_MOBILE", mobile);
            comm.Parameters.AddWithValue("@LOCATION_CONTACT_PHONE", phone);
            comm.Parameters.AddWithValue("@LOCATION_CONTACT_WEBSITE", website);

            comm.ExecuteNonQuery();

            return (int)comm.Parameters["@PKID"].Value;
        }

        public void UpdateLocationContactDetails(int pkid,
                                                 string contactName,
                                                 string mobile,
                                                 string phone,
                                                 string website)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "usp_UpdateLocationContactDetails";

            comm.Parameters.AddWithValue("@PKID", pkid);
            comm.Parameters.AddWithValue("@LOCATION_CONTACT_NAME", contactName);
            comm.Parameters.AddWithValue("@LOCATION_CONTACT_MOBILE", mobile);
            comm.Parameters.AddWithValue("@LOCATION_CONTACT_PHONE", phone);
            comm.Parameters.AddWithValue("@LOCATION_CONTACT_WEBSITE", website);

            comm.ExecuteNonQuery();
        }
    }
}
