using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class User
    {
        public virtual string Id { get; set; }
        public virtual string NickName { get; set; }
        public virtual string RealName { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Address_Number { get; set; }
        public virtual string Address_Street { get; set; }
        public virtual string Address_City { get; set; }
        public virtual string Address_Province { get; set; }
        public virtual string Address_Country { get; set; }
        public virtual string Address_ZipCode { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }
}
