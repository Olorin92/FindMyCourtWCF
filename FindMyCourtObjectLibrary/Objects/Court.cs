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
        private int _pkid;
        private int _locationID;
        private string _courtName;
        private int _courtTypeID;
        private int _backboardTypeID;
        private bool _hasNet;
        private bool _hasScoreboard;
        private string _submittedUserName;
        private bool _isIndoor;

        public int PKID
        {
            get
            {
                return _pkid;
            }
        }
        public int LocationID
        {
            get
            {
                return _locationID;
            }
            set
            {
                _locationID = value;
                OnPropertyChanged("LocationID");
            }
        }
        public string CourtName
        {
            get
            {
                return _courtName;
            }
            set
            {
                _courtName = value;
                OnPropertyChanged("CourtName");
            }
        }
        public int CourtTypeID
        {
            get
            {
                return _courtTypeID;
            }
            set
            {
                _courtTypeID = value;
                OnPropertyChanged("CourtTypeID");
            }
        }
        public int BackboardTypeID
        {
            get
            {
                return _backboardTypeID;
            }
            set
            {
                _backboardTypeID = value;
                OnPropertyChanged("BackboardTypeID");
            }
        }
        public bool HasNet
        {
            get
            {
                return _hasNet;
            }
            set
            {
                _hasNet = value;
            }
        }
        public bool HasScoreboard
        {
            get
            {
                return _hasScoreboard;
            }
            set
            {
                _hasScoreboard = value;
                OnPropertyChanged("HasScoreboard");
            }
        }
        public string SubmittedUserName
        {
            get
            {
                return _submittedUserName;
            }
            set
            {
                _submittedUserName = value;
                OnPropertyChanged("SubmittedUSerName");
            }
        }

        public bool IsIndoor
        {
            get
            {
                return _isIndoor;
            }
            set
            {
                _isIndoor = value;
                OnPropertyChanged("IsIndoor");
            }
        }

        public Court()
        {
            IsNew = true;
        }

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
            _pkid = (int)dr["COURT_ID"];
            _courtName = (string)dr["COURT_NAME"];
            _courtTypeID = (int)dr["COURT_TYPE_ID"];
            _backboardTypeID = (int)dr["BACKBOARD_TYPE_ID"];
            _hasNet = Convert.ToBoolean(dr["HAS_NET"]);
            _hasScoreboard = Convert.ToBoolean(dr["HAS_SCOREBOARD"]);
            _submittedUserName = (string)dr["SUBMITTED_USER_NAME"];
            _locationID = (int)dr["LOCATION_ID"];
            _isIndoor = (bool)dr["IS_INDOOR"];

            IsNew = false;
            IsDirty = false;
        }

        protected override void Insert()
        {
            using (CourtDAL dal = new CourtDAL("environment"))
            {
                _pkid = dal.InsertCourt(CourtName, LocationID, CourtTypeID, BackboardTypeID, HasNet, HasScoreboard, SubmittedUserName);
            }
        }

        protected override void Update()
        {
            using (CourtDAL dal = new CourtDAL("environment"))
            {
                dal.UpdateCourt(_pkid, _courtName, _locationID, _courtTypeID, _backboardTypeID, _hasNet, _hasScoreboard);
            }
        }
    }
}
