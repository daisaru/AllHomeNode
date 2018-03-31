using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class ResetPasswordReqData
    {
        public string Mobile { get; set; }
        public string RandomCode { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
