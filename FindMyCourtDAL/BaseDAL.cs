using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtDAL
{
    public class BaseDAL : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public BaseDAL(string environmentName)
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestServer"].ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection != null)
                Connection.Dispose();
        }
    }
}
