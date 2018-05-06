using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Database.Model;
using NHibernate;

namespace AllHomeNode.Database.Manager
{
    class UserManager
    {
        public void Add(User item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(item);
                session.Flush();
            }
        }

        public bool Update(User item)
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

        public bool Delete(string mobile)
        {
            User item = GetUserByMobile(mobile).ToList()[0];
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

        public bool Delete(User item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    session.Delete(item);
                    session.Flush();
                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public IList<User> GetUser(string id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<User> user = session.QueryOver<User>().Where(c => c.Id == id).List();
                return user;
            }
        }

        public IList<User> GetUserByMobile(string mobile)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<User> user = session.QueryOver<User>().Where(c => c.Mobile == mobile).List();
                return user;
            }
        }

        public IList<User> GetUserList()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<User> list = session.QueryOver<User>().List();
                return list;
            }
        }
    }
}
