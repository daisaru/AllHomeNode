using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Database.Model;

namespace AllHomeNode.Database.Manager
{
    class DeviceRoomBindManager
    {
        public void Add(DeviceRoomBind item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(item);
                session.Flush();
            }
        }

        public bool Update(DeviceRoomBind item)
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

        public bool Delete(DeviceRoomBind item)
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

        public IList<DeviceRoomBind> GetControlPointByDeviceId(string deviceId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<DeviceRoomBind> list = session.QueryOver<DeviceRoomBind>().Where(c => c.Id_Device == deviceId).List();
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
