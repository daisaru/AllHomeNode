using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Database.Model;

namespace AllHomeNode.Database.Manager
{
    class UserGatewayBindManager
    {
        public void Add(UserGatewayBind item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(item);
                session.Flush();
            }
        }

        public bool Update(UserGatewayBind item)
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

        public bool Delete(UserGatewayBind item)
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

        public IList<UserGatewayBind> GetUserDeviceBindByUserId(string userId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<UserGatewayBind> list = session.QueryOver<UserGatewayBind>().Where(
                    c => c.Id_User == userId).List();
                return list;
            }
        }

        public IList<UserGatewayBind> GetUserDeviceBindByDeviceId(string deviceId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<UserGatewayBind> list = session.QueryOver<UserGatewayBind>().Where(
                    c => c.Id_Gateway == deviceId).List();
                return list;
            }
        }

        public IList<UserGatewayBind> GetUserDeviceBindByUserIdAndDeviceId(string userId, string deviceId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<UserGatewayBind> list = session.QueryOver<UserGatewayBind>().Where(
                    c => c.Id_User != userId && c.Id_Gateway == deviceId).List();
                return list;
            }
        }

        public IList<UserGatewayBind> GetUserList()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<UserGatewayBind> list = session.QueryOver<UserGatewayBind>().List();
                return list;
            }
        }
    }
}
