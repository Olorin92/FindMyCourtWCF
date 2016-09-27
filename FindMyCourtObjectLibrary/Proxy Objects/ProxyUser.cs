using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtObjectLibrary.Proxy_Objects
{
    [DataContract]
    public class ProxyUser
    {
        [DataMember]
        public int PKID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string Salt { get; set; }
        [DataMember]
        public string SaltedPassword { get; set; }
        [DataMember]
        public int? HomeLocationID { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
