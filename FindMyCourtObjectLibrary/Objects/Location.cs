using FindMyCourtDAL;
using Newtonsoft.Json;
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
        private List<Court> _courts;
        private List<Review> _reviews;
        private string _locationDescription;

        public int PKID
        {
            get
            {
                return _pkid;
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

        public List<Court> Courts
        {
            get
            {
                if (_courts == null)
                    _courts = Court.GetCourts(PKID);
                return _courts;
            }
            set
            {
                _courts = value;
            }
        }

        [JsonIgnore]
        public List<Review> Reviews
        {
            get
            {
                if (_reviews == null)
                    _reviews = Review.GetLocationReviews(PKID);

                return _reviews;
            }
        }

        public double? AverageReviewScore
        {
            get
            {
                double? reviewAverage = null;
                int reviewTotal = 0;

                if (Reviews.Count > 0)
                {
                    foreach (Review review in Reviews)
                    {
                        reviewTotal += review.ReviewRating;
                    }

                    reviewAverage = reviewTotal / Reviews.Count;
                }

                return reviewAverage;
            }
        }

        public int NumberOfCourts
        {
            get
            {
                return Courts.Count;
            }
        }

        public bool HasIndoor
        {
            get
            {
                foreach(Court court in Courts)
                {
                    if (court.IsIndoor)
                        return true;
                }

                return false;
            }
        }

        public bool HasOutdoor
        {
            get
            {
                foreach(Court court in Courts)
                {
                    if (!court.IsIndoor)
                        return true;
                }

                return false;
            }
        }

        public string LocationDescription
        {
            get
            {
                return _locationDescription;
            }
            set
            {
                _locationDescription = value;
                OnPropertyChanged("LocationDescription");
            }
        }

        public Location()
        {
            IsNew = true;
        }

        public static List<Location> GetLocations(double? minLat, double? maxLat, double? minLon, double? maxLon, bool onlyIndoor, bool onlyOutdoor)
        {
            List<Location> locations = new List<Location>();

            try
            {
                using (LocationDAL dal = new LocationDAL("environmentName"))
                {
                    using (SqlDataReader dr = dal.GetLocations(minLat, maxLat, minLon, maxLon, onlyIndoor, onlyOutdoor))
                    {
                        while (dr.Read())
                        {
                            Location loc = new Location();
                            loc.Fetch(dr);

                            locations.Add(loc);
                        }
                    }
                }
            }
            catch(Exception ex)
            {

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
            _locationDescription = dr["LOCATION_DESCRIPTION"] as string;
            _submittedUserName = (string)dr["CREATE_USER_NAME"];

            IsDirty = false;
            IsNew = false;
        }

        protected override void Insert()
        {
            using (LocationDAL dal = new LocationDAL("environmentName"))
            {
                _pkid = dal.InsertLocation(_name, _longitude, _latitude, _submittedUserName, _locationDescription);
            }

            foreach(Court court in Courts)
            {
                court.LocationID = _pkid;
                court.Save();
            }
        }

        protected override void Update()
        {
            using (LocationDAL dal = new LocationDAL("environmentName"))
            {
                dal.UpdateLocation(_pkid, _name, _longitude, _latitude, _locationDescription);
            }
        }
    }
}
