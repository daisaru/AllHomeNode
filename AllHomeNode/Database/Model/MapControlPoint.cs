using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class MapControlPoint:ClassMap<ControlPoint>
    {
        public MapControlPoint()
        {
            Id(x => x.Id).Column("Id");

            Map(x => x.Id_Device).Column("Id_Device");
            Map(x => x.Name).Column("Name");
            Map(x => x.Code).Column("Code");
            Map(x => x.Type).Column("Type");
            Map(x => x.Point).Column("Point");
            Map(x => x.Brand).Column("Brand");
            Map(x => x.Model).Column("Model");
            Map(x => x.TimeStamp).Column("TimeStamp");

            Table("tb_controlpoint");
        }
    }
}
