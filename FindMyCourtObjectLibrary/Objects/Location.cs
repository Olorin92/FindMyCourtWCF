using FindMyCourtDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtObjectLibrary.Objects
{
    public class Location : SaveableObject
    {
        private int _pkid;
        private string _name;
        private double _longitude;
        private double _latitude;
        private string _submittedUserName;

        public int PKID
        {
            get
            {
                return _pkid;
            }
            set
            {
                _pkid = value;
                OnPropertyChanged("PKID");
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public double Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                _longitude = value;
                OnPropertyChanged("Longitude");
            }
        }

        public double Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                _latitude = value;
                OnPropertyChanged("Latitude");
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
                OnPropertyChanged("SubmittedUserName");
            }
        }

        public Location()
        {
            IsNew = true;
        }

        public static List<Location> GetLocations(double minLat, double maxLat, double minLon, double maxLon)
        {
            List<Location> locations = new List<Location>();

            using (LocationDAL dal = new LocationDAL("environmentName"))
            {
                using (SqlDataReader dr = dal.GetLocations(minLat, maxLat, minLon, maxLon))
                {
                    while (dr.Read())
                    {
                        Location loc = new Location();
                        loc.Fetch(dr);

                        locations.Add(loc);
                    }
                }
            }

            return locations;
        }

        public static Location GetLocation(int locationID)
        {
            Location location = new Location();

            using (LocationDAL dal = new LocationDAL("environmentName"))
            {
                using (SqlDataReader dr = dal.GetLocation(locationID))
                {
                    dr.Read();
                    location.Fetch(dr);
                }
            }

            return location;
        }

        private void Fetch(SqlDataReader dr)
        {
            _pkid = (int)dr["LOCATION_ID"];
            _name = (string)dr["LOCATION_NAME"];
            _longitude = (double)dr["LONGITUDE"];
            _latitude = (double)dr["LATITUDE"];
            _submittedUserName = (string)dr["CREATE_USER_NAME"];

            IsDirty = false;
            IsNew = false;
        }

        protected override void Insert()
        {
            using (LocationDAL dal = new LocationDAL("environmentName"))
            {
                _pkid = dal.InsertLocation(_name, _longitude, _latitude, _submittedUserName);
            }
        }

        protected override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
