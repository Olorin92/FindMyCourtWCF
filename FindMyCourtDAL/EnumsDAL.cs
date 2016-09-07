using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtDAL
{
    public class EnumsDAL : BaseDAL
    {
        public EnumsDAL(string environmentName) : base(environmentName)
        {
        }

        public SqlDataReader GetCourtTypes()
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "usp_GetCourtTypes";

            return comm.ExecuteReader();
        }

        public SqlDataReader GetBackboardTypes()
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "usp_GetBackboardTypes";

            return comm.ExecuteReader();
        }

        public SqlDataReader GetReviewTypes()
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "usp_GetReviewTypes";

            return comm.ExecuteReader();
        }
    }
}
