﻿using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class MapDevice : ClassMap<Device>
    {
        public MapDevice()
        {
            Id(x => x.Id).Column("Id");

            Map(x => x.DeviceId).Column("DeviceId");
            Map(x => x.DeviceName).Column("DeviceName");
            Map(x => x.TimeStamp).Column("TimeStamp");

            Table("tb_device");
        }
    }
}