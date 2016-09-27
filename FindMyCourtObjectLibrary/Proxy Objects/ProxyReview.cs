using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtObjectLibrary.Proxy_Objects
{
    [DataContract]
    public class ProxyReview
    {
        [DataMember]
        public int PKID { get; set; }
        [DataMember]
        public int ReviewTypeID { get; set; }
        [DataMember]
        public int ReviewEntityID { get; set; }
        [DataMember]
        public string ReviewComment { get; set; }
        [DataMember]
        public byte ReviewRating { get; set; }
        [DataMember]
        public string SubmittedUserName { get; set; }
    }
}
