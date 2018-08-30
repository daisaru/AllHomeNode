using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallationTool.Front
{
    public class LoginReqData
    {
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string OldToken { get; set; }
    }
}
