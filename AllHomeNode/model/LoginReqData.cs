﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.model
{
    public class LoginReqData
    {
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string OldToken { get; set; }
    }
}
