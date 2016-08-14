using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtObjectLibrary.Objects
{
    public class Court
    {
        public int PKID { get; set; }
        public string CourtName { get; set; }
        public int CourtTypeID { get; set; }
        public int BackboardTypeID { get; set; }
        public bool HasNet { get; set; }
        public bool HasScoreboard { get; set; }
        public int SubmittedUserID { get; set; }
    }
}
