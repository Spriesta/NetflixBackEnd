using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.Common
{
    public class Helpers
    {
        //sonra web config de alır gibi yap
        public static string getConnStr()
        {
            return "Data Source=BOSS\\BOSS;Database = Alfa;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
    }
}
