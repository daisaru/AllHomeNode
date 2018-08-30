using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallationTool.Front
{
    public class UserData
    {
        public UserData()
        {
            Address = new Address();
        }
        public string NickName { get; set; }
        public string RealName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SquareMeter { get; set; }
        public string PeakElectricity { get; set; }
        public string ValleyElectricity { get; set; }
        public string RandomCode { get; set; }
        public Address Address { get; set; }
    }
}
