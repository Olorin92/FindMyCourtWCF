using FindMyCourtDAL;
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
            set
            {
                _pkid = value;
                OnPropertyChanged("PKID");
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

        public string Salt
        {
            get
            {
                return _salt;
            }
            set
            {
                _salt = value;
                OnPropertyChanged("Salt");
            }
        }

        //public string SaltedPassword
        //{
        //    get
        //    {
        //        return _saltedPassword;
        //    }
        //    set
        //    {
        //        _saltedPassword = value;
        //        OnPropertyChanged("SaltedPassword");
        //    }
        //}

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
                GenerateSaltedPassword();
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

        public static User GetUser(string email, string username)
        {
            User user = new User();

            using (UserDAL dal = new UserDAL("environment"))
            {
                using (SqlDataReader dr = dal.GetUser(email, username))
                {
                    dr.Read();
                    user = new User();
                    user.Fetch(dr);
                }
            }

            return user;
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
                PKID = dal.CreateUser(FirstName, LastName, UserName, EmailAddress, Salt, _saltedPassword);
            }
        }

        protected override void Update()
        {

        }

        private void GenerateSaltedPassword()
        {
            if (_salt == null)
                _salt = SaltGenerator(new RNGCryptoServiceProvider(), 256);

            byte[] hashBytes;

            using (SHA256 hash = SHA256.Create())
            {
                hashBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(_password + _salt));
            }

            // Use StringBuilder for performance
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }

            _saltedPassword = sb.ToString();
        }

        private string SaltGenerator(RNGCryptoServiceProvider crypto, int size)
        {
            byte[] bytes = new byte[size];
            crypto.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
