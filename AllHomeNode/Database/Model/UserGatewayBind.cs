using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class UserGatewayBind
    {
        public virtual string Id { get; set; }
        public virtual string Id_User { get; set; }
        public virtual string Id_Gateway { get; set; }
        public virtual string GatewayGivenName { get; set; }
        public virtual string Privilege { get; set; }
        public virtual string Time { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }
}
