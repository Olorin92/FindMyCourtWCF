using FindMyCourtObjectLibrary.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace FindMyCourt.Rest_Implementation
{
    public static class UserRest
    {
        public static int InsertUser(string user)
        {
            User newUser = JsonConvert.DeserializeObject<User>(user);
            newUser.Save();

            return newUser.PKID;
        }

        public static Stream GetUser(string pkid)
        {
            User user = User.GetUser(Convert.ToInt32(pkid));
            string serialization = JsonConvert.SerializeObject(user);
            return new MemoryStream(Encoding.UTF8.GetBytes(serialization));
        }

        public static Stream GetUser(string email, string username)
        {
            User user = User.GetUser(email, username);
            string serialization = JsonConvert.SerializeObject(user);
            return new MemoryStream(Encoding.UTF8.GetBytes(serialization));
        }

        public static Stream GetUsers()
        {
            List<User> users = User.GetUsers();
            string serialization = JsonConvert.SerializeObject(users);
            return new MemoryStream(Encoding.UTF8.GetBytes(serialization));
        }
    }
}