using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Auth
{
    public class Token
    {
        public string TokenString { get; set; }
        public DateTime StartTime { get; set; }       
        public int TokenLife { get; set; }
    }
}
