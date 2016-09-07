using FindMyCourtDAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace FindMyCourt.Rest_Implementation
{
    public static class EnumsRest
    {
        public static Stream GetCourtTypes()
        {
            Dictionary<int, string> courtTypes = new Dictionary<int, string>();

            using (EnumsDAL dal = new EnumsDAL("environment"))
            {
                using (SqlDataReader dr = dal.GetCourtTypes())
                {
                    while(dr.Read())
                    {
                        courtTypes.Add((int)dr["COURT_TYPE_ID"], (string)dr["COURT_TYPE_NAME"]);
                    }
                }
            }

            string serialization = JsonConvert.SerializeObject(courtTypes);

            return new MemoryStream(Encoding.UTF8.GetBytes(serialization));
        }

        public static Stream GetBackboardTypes()
        {
            Dictionary<int, string> backboardTypes = new Dictionary<int, string>();

            using (EnumsDAL dal = new EnumsDAL("environment"))
            {
                using (SqlDataReader dr = dal.GetBackboardTypes())
                {
                    while (dr.Read())
                    {
                        backboardTypes.Add((int)dr["BACKBOARD_TYPE_ID"], (string)dr["BACKBOARD_TYPE_NAME"]);
                    }
                }
            }

            string serialization = JsonConvert.SerializeObject(backboardTypes);

            return new MemoryStream(Encoding.UTF8.GetBytes(serialization));
        }

        public static Stream GetReviewTypes()
        {
            Dictionary<int, string> reviewTypes = new Dictionary<int, string>();

            using (EnumsDAL dal = new EnumsDAL("environment"))
            {
                using (SqlDataReader dr = dal.GetReviewTypes())
                {
                    while (dr.Read())
                    {
                        reviewTypes.Add((int)dr["REVIEW_TYPE_ID"], (string)dr["REVIEW_TYPE_NAME"]);
                    }
                }
            }

            string serialization = JsonConvert.SerializeObject(reviewTypes);

            return new MemoryStream(Encoding.UTF8.GetBytes(serialization));
        }
    }
}