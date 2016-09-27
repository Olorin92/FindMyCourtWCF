using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtObjectLibrary.Proxy_Objects
{
    [DataContract]
    public class ProxyLocationContactDetails
    {
        [DataMember]
        public int PKID { get; set; }
        [DataMember]
        public string ContactName { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Website { get; set; }
    }
}
