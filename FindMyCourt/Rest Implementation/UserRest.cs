using FindMyCourtObjectLibrary.Objects;
using FindMyCourtObjectLibrary.Proxy_Objects;
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
        public static int InsertUser(ProxyUser user)
        {
            User newUser = JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(user));
            newUser.Save();

            return newUser.PKID;
        }

        public static int UpdateUser(string pkid, ProxyUser user)
        {
            User existingUser = User.GetUser(Convert.ToInt32(pkid));
            JsonConvert.PopulateObject(JsonConvert.SerializeObject(user), existingUser);
            existingUser.Save();

            return existingUser.PKID;
        }

        public static ProxyUser GetUser(string pkid)
        {
            User user = User.GetUser(Convert.ToInt32(pkid));
            string serialization = JsonConvert.SerializeObject(user);
            return JsonConvert.DeserializeObject<ProxyUser>(serialization);
        }

        public static Stream GetUsers(string email, string username)
        {
            List<User> users = User.GetUsers(email, username);
            string serialization = JsonConvert.SerializeObject(users);
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