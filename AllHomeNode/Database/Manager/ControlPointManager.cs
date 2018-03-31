using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Database.Model;
using NHibernate;

namespace AllHomeNode.Database.Manager
{
    class ControlPointManager
    {
        public void Add(ControlPoint item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(item);
                session.Flush();
            }
        }

        public bool Update(ControlPoint item)
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
                    return false;
                }
            }
        }

        public bool Delete(ControlPoint item)
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
                    return false;
                }
            }
        }

        public IList<ControlPoint> GetControlPointByRoom(string roomId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<ControlPoint> controlPoint = session.QueryOver<ControlPoint>().Where(c => c.Id_Room == roomId).List();
                return controlPoint;
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
