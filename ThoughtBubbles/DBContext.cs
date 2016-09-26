using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using ServiceStack.OrmLite;

namespace ThoughtBubbles
{
    public class DBContext
    {
        private static string DbConnection { get; set; }
        public static OrmLiteConnectionFactory Factory { get; set; }
        private bool isPROD { get; set; }

        public DBContext()
        {
            isPROD = true;
#if DEBUG
            isPROD = false;
#endif
            Factory = new OrmLiteConnectionFactory(Dbswitcher(), SqlServerDialect.Provider);
        }

        private string Dbswitcher()
        {
            return isPROD ?
                 "Server=tcp:4thsanctuary.database.windows.net,1433;Initial Catalog=SQL_4thSanctuary;Persist Security Info=False;User ID=codfractal;Password=ADTuECOyY3t0;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                  : "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ThoughtBubbles.MotivationContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                 ;

        }

    }
}