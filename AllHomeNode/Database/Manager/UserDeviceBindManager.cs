using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Database.Model;

namespace AllHomeNode.Database.Manager
{
    class UserDeviceBindManager
    {
        public void Add(UserDeviceBind item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(item);
                session.Flush();
            }
        }

        public bool Update(UserDeviceBind item)
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

        public bool Delete(UserDeviceBind item)
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

        public IList<UserDeviceBind> GetUserDeviceBindByUserId(string userId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<UserDeviceBind> list = session.QueryOver<UserDeviceBind>().Where(
                    c => c.Id_User == userId).List();
                return list;
            }
        }

        public IList<UserDeviceBind> GetUserDeviceBindByDeviceId(string deviceId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<UserDeviceBind> list = session.QueryOver<UserDeviceBind>().Where(
                    c => c.Id_Device == deviceId).List();
                return list;
            }
        }

        public IList<UserDeviceBind> GetUserDeviceBindByUserIdAndDeviceId(string userId, string deviceId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<UserDeviceBind> list = session.QueryOver<UserDeviceBind>().Where(
                    c => c.Id_User != userId && c.Id_Device == deviceId).List();
                return list;
            }
        }

        public IList<UserDeviceBind> GetUserList()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<UserDeviceBind> list = session.QueryOver<UserDeviceBind>().List();
                return list;
            }
        }
    }
}
