using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtDAL
{
    public class ReviewDAL : BaseDAL
    {
        public ReviewDAL(string environmentName) : base(environmentName)
        {
        }

        public SqlDataReader GetReview(int reviewID)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "usp_GetCourtReview";

            comm.Parameters.AddWithValue("@REVIEW_ID", reviewID);

            return comm.ExecuteReader();
        }

        public SqlDataReader GetCourtReviews(int courtID)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "usp_GetCourtReviews";

            comm.Parameters.AddWithValue("@COURT_ID", courtID);

            return comm.ExecuteReader();
        }

        public SqlDataReader GetLocationReviews(int locationID)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "usp_GetLocationReviews";

            comm.Parameters.AddWithValue("@LOCATION_ID", locationID);

            return comm.ExecuteReader();
        }

        public int InsertReview(int reviewTypeID,
                                int reviewEntityID,
                                string reviewComment,
                                byte reviewRating,
                                string submittedUserName)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "usp_InsertReview";

            comm.Parameters.Add("@PKID", SqlDbType.Int);
            comm.Parameters[0].Direction = ParameterDirection.Output;
            comm.Parameters.AddWithValue("@REVIEW_TYPE_ID", reviewTypeID);
            comm.Parameters.AddWithValue("@REVIEW_ENTITY_ID", reviewEntityID);
            comm.Parameters.AddWithValue("@REVIEW_COMMENT", reviewComment);
            comm.Parameters.AddWithValue("@REVIEW_RATING", reviewRating);
            comm.Parameters.AddWithValue("@SUBMITTED_USER_NAME", submittedUserName);

            comm.ExecuteNonQuery();

            return (int)comm.Parameters["@PKID"].Value;
        }

        public void UpdateReview(int pkid,
                                 int reviewTypeID,
                                 int reviewEntityID,
                                 string reviewComment,
                                 byte reviewRating)
        {
            SqlCommand comm = Connection.CreateCommand();
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = "usp_InsertReview";

            comm.Parameters.AddWithValue("@PKID", pkid);
            comm.Parameters.AddWithValue("@REVIEW_TYPE_ID", reviewTypeID);
            comm.Parameters.AddWithValue("@REVIEW_ENTITY_ID", reviewEntityID);
            comm.Parameters.AddWithValue("@REVIEW_COMMENT", reviewComment);
            comm.Parameters.AddWithValue("@REVIEW_RATING", reviewRating);

            comm.ExecuteNonQuery();
        }
    }
}
