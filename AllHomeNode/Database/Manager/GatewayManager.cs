﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Database.Model;

namespace AllHomeNode.Database.Manager
{
    class GatewayManager
    {
        public void Add(Gateway item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(item);
                session.Flush();
            }
        }
        public bool Update(Gateway item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    session.Update(item);
                    session.Flush();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool Delete(string deviceId)
        {
            Gateway item = GetDeviceById(deviceId).ToList()[0];
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    session.Delete(item);
                    session.Flush();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool Delete(Gateway item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    session.Delete(item);
                    session.Flush();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public IList<Gateway> GetDeviceByDeviceId(string deviceId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<Gateway> device = session.QueryOver<Gateway>().Where(c => c.GatewayId == deviceId).List();
                return device;
            }
        }

        public IList<Gateway> GetDeviceById(string id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<Gateway> device = session.QueryOver<Gateway>().Where(c => c.Id == id).List();
                return device;
            }
        }

        public IList<Gateway> GetDeviceList()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<Gateway> list = session.QueryOver<Gateway>().List();
                return list;
            }
        }

        public void AddHeartbeat(Heartbeat item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(item);
                session.Flush();
            }
        }
    }
}
