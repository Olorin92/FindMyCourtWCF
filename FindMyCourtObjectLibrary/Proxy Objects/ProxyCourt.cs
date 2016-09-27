using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtObjectLibrary.Proxy_Objects
{
    [DataContract]
    public class ProxyCourt
    {
        [DataMember]
        public int PKID { get; set; }
        [DataMember]
        public int LocationID { get; set; }
        [DataMember]
        public string CourtName { get; set; }
        [DataMember]
        public int CourtTypeID { get; set; }
        [DataMember]
        public int BackboardTypeID { get; set; }
        [DataMember]
        public bool HasNet { get; set; }
        [DataMember]
        public bool HasScoreboard { get; set; }
        [DataMember]
        public string SubmittedUserName { get; set; }
        [DataMember]
        public bool IsIndoor { get; set; }
    }
}
