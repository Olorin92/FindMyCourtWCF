using FindMyCourtDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtObjectLibrary.Objects
{
    public class LocationContactDetails : SaveableObject
    {
        private int _pkid;
        private string _contactName;
        private string _mobile;
        private string _phone;
        private string _website;

        public int PKID
        {
            get
            {
                return _pkid;
            }
        }

        public string ContactName
        {
            get
            {
                return _contactName;
            }
            set
            {
                _contactName = value;
                OnPropertyChanged("ContactName");
            }
        }

        public string Mobile
        {
            get
            {
                return _mobile;
            }
            set
            {
                _mobile = value;
                OnPropertyChanged("Mobile");
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public string Website
        {
            get
            {
                return _website;
            }
            set
            {
                _website = value;
                OnPropertyChanged("Website");
            }
        }

        public LocationContactDetails()
        {
            IsNew = true;
        }

        public static LocationContactDetails GetLocationContactDetails(int locationID)
        {
            LocationContactDetails contactDetails = new LocationContactDetails();

            try
            {
                using (LocationContactDetailsDAL dal = new LocationContactDetailsDAL("environment"))
                {
                    using (SqlDataReader dr = dal.GetLocationContactDetails(locationID))
                    {
                        dr.Read();
                        contactDetails.Fetch(dr);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            if (contactDetails.PKID == 0)
                return null;
            else
                return contactDetails;
        }

        private void Fetch(SqlDataReader dr)
        {
            _pkid = (int)dr["LOCATION_CONTACT_DETAILS_ID"];
            _contactName = (string)dr["LOCATION_CONTACT_NAME"];
            _mobile = (string)dr["LOCATION_CONTACT_MOBILE"];
            _phone = (string)dr["LOCATION_CONTACT_PHONE"];
            _website = (string)dr["LOCATION_CONTACT_WEBSITE"];
        }

        protected override void Insert()
        {
            using (LocationContactDetailsDAL dal = new LocationContactDetailsDAL("environment"))
            {
                _pkid = dal.InsertLocationContactDetails(ContactName, Mobile, Phone, Website);
            }
        }

        protected override void Update()
        {
            using (LocationContactDetailsDAL dal = new LocationContactDetailsDAL("environment"))
            {
                dal.UpdateLocationContactDetails(_pkid, _contactName, _mobile, _phone, _website);
            }
        }
    }
}
