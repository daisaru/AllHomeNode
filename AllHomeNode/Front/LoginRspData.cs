using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class LoginRspData : ReturnResult
    {
        public string Token { get; set; }
        public string TokenLife { get; set; }
        public UserData UserData { get; set; }
        public string TimeStamp { get; set; }
    }
}
