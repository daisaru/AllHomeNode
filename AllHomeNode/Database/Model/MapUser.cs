using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class MapUser : ClassMap<User>
    {
        public MapUser()
        {
            Id(x => x.Id).Column("Id");

            Map(x => x.NickName).Column("NickName");
            Map(x => x.RealName).Column("RealName");
            Map(x => x.Mobile).Column("Mobile");
            Map(x => x.Email).Column("Email");
            Map(x => x.Password).Column("Password");
            Map(x => x.Address_Number).Column("Address_Number");
            Map(x => x.Address_Street).Column("Address_Street");
            Map(x => x.Address_City).Column("Address_City");
            Map(x => x.Address_Province).Column("Address_Province");
            Map(x => x.Address_Country).Column("Address_Country");
            Map(x => x.Address_ZipCode).Column("Address_ZipCode");
            Map(x => x.TimeStamp).Column("TimeStamp");

            Table("tb_user");
        }
    }
}
