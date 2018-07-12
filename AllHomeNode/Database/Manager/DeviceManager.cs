using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Database.Model;

namespace AllHomeNode.Database.Manager
{
    class DeviceManager
    {
        public void Add(Device item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(item);
                session.Flush();
            }
        }

        public bool Update(Device item)
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

        public bool Delete(Device item)
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

        public IList<Device> GetRoomByRoomId(string id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<Device> list = session.QueryOver<Device>().Where(c => c.Id == id).List();
                return list;
            }
        }

        public IList<Device> GetUserList()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<Device> list = session.QueryOver<Device>().List();
                return list;
            }
        }
    }
}
