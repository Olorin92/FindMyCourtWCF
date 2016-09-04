using FindMyCourtDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtObjectLibrary.Objects
{
    public class Court : SaveableObject
    {
        public int PKID { get; set; }
        public string CourtName { get; set; }
        public int CourtTypeID { get; set; }
        public int BackboardTypeID { get; set; }
        public bool HasNet { get; set; }
        public bool HasScoreboard { get; set; }
        public string SubmittedUserName { get; set; }

        public static Court GetCourt(int pkid)
        {
            Court court = new Court();

            using (CourtDAL dal = new CourtDAL("environment"))
            {
                using (SqlDataReader dr = dal.GetCourt(pkid))
                {
                    dr.Read();
                    court.Fetch(dr);
                }
            }

            return court;
        }

        public static List<Court> GetCourts(int locationID)
        {
            List<Court> courts = new List<Court>();

            using (CourtDAL dal = new CourtDAL("environment"))
            {
                using (SqlDataReader dr = dal.GetCourts(locationID))
                {
                    while (dr.Read())
                    {
                        Court court = new Court();
                        court.Fetch(dr);
                        courts.Add(court);
                    }
                }
            }

            return courts;
        }

        private void Fetch(SqlDataReader dr)
        {
            PKID = (int)dr["COURT_ID"];
            CourtName = (string)dr["COURT_NAME"];
            CourtTypeID = (int)dr["COURT_TYPE_ID"];
            BackboardTypeID = (int)dr["BACKBOARD_TYPE_ID"];
            HasNet = Convert.ToBoolean((int)dr["HAS_NET"]);
            HasScoreboard = Convert.ToBoolean((int)dr["HAS_SCOREBOARD"]);
            SubmittedUserName = (string)dr["SUBMITTED_USER_NAME"];

            IsNew = false;
            IsDirty = false;
        }

        protected override void Insert()
        {
            throw new NotImplementedException();
        }

        protected override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
