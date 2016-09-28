using FindMyCourtDAL;
using FindMyCourtObjectLibrary.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtObjectLibrary.Objects
{
    public class User : SaveableObject
    {
        private int _pkid;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _emailAddress;
        private string _salt;
        private string _saltedPassword;
        private string _password;
        private int? _homeLocationID;

        #region Properties

        public int PKID
        {
            get
            {
                return _pkid;
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                _emailAddress = value;
                OnPropertyChanged("EmailAddress");
            }
        }

        //[JsonIgnore]
        public string Salt
        {
            get
            {
                return _salt;
            }
            //set
            //{
            //    _salt = value;
            //    OnPropertyChanged("Salt");
            //}
        }

        //[JsonIgnore]
        public string SaltedPassword
        {
            get
            {
                return _saltedPassword;
            }
            //set
            //{
            //    _saltedPassword = value;
            //    OnPropertyChanged("SaltedPassword");
            //}
        }

        public int? HomeLocationID
        {
            get
            {
                return _homeLocationID;
            }
            set
            {
                _homeLocationID = value;
                OnPropertyChanged("HomeLocationID");
            }
        }

        // This will only be used when creating a user or updating a password
        // We will not store the plaintext password, only the salted version
        public string Password
        {
            //get
            //{
            //    return _password;
            //}
            set
            {
                _password = value;

                if (_salt == null)
                    _salt = SaltedPasswordUtility.GenerateSalt();

                _saltedPassword = SaltedPasswordUtility.GenerateSaltedPassword(_salt, _password);
            }
        }

        #endregion

        public User()
        {
            IsNew = true;
        }

        public static User GetUser(int pkid)
        {
            User user = new User();

            using (UserDAL dal = new UserDAL("environment"))
            {
                using (SqlDataReader dr = dal.GetUser(pkid))
                {
                    dr.Read();
                    user.Fetch(dr);
                }
            }

            return user;
        }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (UserDAL dal = new UserDAL("environment"))
            {
                using (SqlDataReader dr = dal.GetUsers())
                {
                    while (dr.Read())
                    {
                        User user = new User();
                        user.Fetch(dr);

                        users.Add(user);
                    }
                }
            }

            return users;
        }

        public static List<User> GetUsers(string email, string username)
        {
            List<User> users = new List<User>();

            try
            {
                using (UserDAL dal = new UserDAL("environment"))
                {
                    using (SqlDataReader dr = dal.GetUsers(email, username))
                    {
                        while (dr.Read())
                        {
                            User user = new User();
                            user.Fetch(dr);

                            users.Add(user);
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return users;
        }

        private void Fetch(SqlDataReader dr)
        {
            _pkid = (int)dr["USER_ID"];
            _firstName = (string)dr["USER_FIRST_NAME"];
            _lastName = (string)dr["USER_LAST_NAME"];
            _userName = (string)dr["USER_NAME"];
            _emailAddress = (string)dr["EMAIL_ADDRESS"];
            _salt = (string)dr["SALT"];
            _saltedPassword = (string)dr["SALTED_PASSWORD"];
            _homeLocationID = dr["HOME_LOCATION_ID"].ToString() == string.Empty ? (int?)null : (int)dr["HOME_LOCATION_ID"];

            IsNew = false;
            IsDirty = false;
        }

        protected override void Insert()
        {
            using (UserDAL dal = new UserDAL("environment"))
            {
                _pkid = dal.CreateUser(FirstName, LastName, UserName, EmailAddress, Salt, _saltedPassword);
            }
        }

        protected override void Update()
        {
            using (UserDAL dal = new UserDAL("environment"))
            {
                dal.UpdateUser(_pkid, _firstName, _lastName, _userName, _emailAddress, _salt, _saltedPassword);
            }
        }
    }
}
