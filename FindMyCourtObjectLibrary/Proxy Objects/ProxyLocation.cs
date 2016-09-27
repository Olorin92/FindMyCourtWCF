using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtObjectLibrary.Proxy_Objects
{
    [DataContract]
    public class ProxyLocation
    {
        [DataMember]
        public int PKID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Longitude { get; set; }
        [DataMember]
        public double Latitude { get; set; }
        [DataMember]
        public string SubmittedUserName { get; set; }
        [DataMember]
        public double? AverageReviewScore { get; set; }
        [DataMember]
        public int NumberOfCourts { get; set; }
        [DataMember]
        public List<ProxyCourt> Courts { get; set; }
        [DataMember]
        public List<ProxyReview> Reviews { get; set; }
        [DataMember]
        public bool HasIndoor { get; set; }
        [DataMember]
        public bool HasOutdoor { get; set; }
    }
}
