using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtDAL
{
    public class UserDAL : BaseDAL
    {
        public UserDAL(string environmentName)
            : base(environmentName)
        {
            
        }

        public SqlDataReader GetUser(int pkid)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;

            comm.CommandText = "usp_GetUser";
            comm.Parameters.AddWithValue("@PKID", pkid);

            return comm.ExecuteReader();
        }

        public SqlDataReader GetUsers()
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;

            comm.CommandText = "usp_GetUsers";

            return comm.ExecuteReader();
        }

        public SqlDataReader GetUsers(string email, string username)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "usp_GetUserFiltered";

            comm.Parameters.AddWithValue("@EMAIL", email);
            comm.Parameters.AddWithValue("@USER_NAME", username);

            return comm.ExecuteReader();
        }

        public int CreateUser(string firstName,
                              string lastName,
                              string userName,
                              string emailAddress,
                              string salt,
                              string saltedPassword)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "usp_InsertUser";

            comm.Parameters.Add("@PKID", System.Data.SqlDbType.Int);
            comm.Parameters[0].Direction = System.Data.ParameterDirection.Output;
            comm.Parameters.AddWithValue("@FIRST_NAME", firstName);
            comm.Parameters.AddWithValue("@LAST_NAME", lastName);
            comm.Parameters.AddWithValue("@USER_NAME", userName);
            comm.Parameters.AddWithValue("@EMAIL_ADDRESS", emailAddress);
            comm.Parameters.AddWithValue("@SALT", salt);
            comm.Parameters.AddWithValue("@SALTED_PASSWORD", saltedPassword);

            comm.ExecuteNonQuery();

            return (int)comm.Parameters[0].Value;
        }

        public void UpdateUser(int pkid,
                              string firstName,
                              string lastName,
                              string userName,
                              string emailAddress,
                              string salt,
                              string saltedPassword)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandText = "usp_UpdateUser";
            comm.CommandType = System.Data.CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@PKID", pkid);
            comm.Parameters.AddWithValue("@FIRST_NAME", firstName);
            comm.Parameters.AddWithValue("@LAST_NAME", lastName);
            comm.Parameters.AddWithValue("@USER_NAME", userName);
            comm.Parameters.AddWithValue("@EMAIL_ADDRESS", emailAddress);
            comm.Parameters.AddWithValue("@SALT", salt);
            comm.Parameters.AddWithValue("@SALTED_PASSWORD", saltedPassword);

            comm.ExecuteNonQuery();
        }
    }
}
