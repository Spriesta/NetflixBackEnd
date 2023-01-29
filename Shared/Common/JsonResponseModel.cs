using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.Models
{
    public class JsonResponseModel
    {
        public Boolean success { get; set; }

        public object data { get; set; }
    }
}
