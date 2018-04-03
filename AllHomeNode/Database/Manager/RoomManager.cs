using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Database.Model;

namespace AllHomeNode.Database.Manager
{
    class RoomManager
    {
        public void Add(Room item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(item);
                session.Flush();
            }
        }

        public bool Update(Room item)
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

        public bool Delete(Room item)
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

        public IList<Room> GetRoomByRoomId(string id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<Room> list = session.QueryOver<Room>().Where(c => c.Id == id).List();
                return list;
            }
        }

        public IList<Room> GetUserList()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<Room> list = session.QueryOver<Room>().List();
                return list;
            }
        }
    }
}
