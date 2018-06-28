using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class MapRoom : ClassMap<Room>
    {
        public MapRoom()
        {
            Id(x => x.Id).Column("Id");

            Map(x => x.Name).Column("Name");
            Map(x => x.Type).Column("Type");
            Map(x => x.Size).Column("Size");
            Map(x => x.TimeStamp).Column("TimeStamp");

            Table("tb_room");
        }
    }
}
