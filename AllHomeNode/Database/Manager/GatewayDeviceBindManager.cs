using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Database.Model;
using NHibernate;

namespace AllHomeNode.Database.Manager
{
    class GatewayDeviceBindManager
    {
        public void Add(GatewayDeviceBind item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(item);
                session.Flush();
            }
        }

        public bool Update(GatewayDeviceBind item)
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
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    int count = session.Delete("from GatewayDeviceBind where ID_Device = ?", deviceId, NHibernateUtil.String);
                    session.Flush();
                    return count >= 0 ? true : false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool Delete(GatewayDeviceBind item)
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

        public IList<GatewayDeviceBind> GetBindsByGatewayId(string GatewayId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<GatewayDeviceBind> list = session.QueryOver<GatewayDeviceBind>().Where(c => c.Id_Gateway == GatewayId).List();
                return list;
            }
        }

        public IList<ControlPoint> GetUserList()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<ControlPoint> list = session.QueryOver<ControlPoint>().List();
                return list;
            }
        }
    }
}
