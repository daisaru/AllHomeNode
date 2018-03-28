using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.model
{
    public class LoginRspData : ReturnResult
    {
        public string Token { get; set; }
        public string TokenLife { get; set; }
        public string TimeStamp { get; set; }
    }
}
