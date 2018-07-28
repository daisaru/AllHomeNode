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
                    int count = session.Delete("from ControlPoint where ID_Device = ?", deviceId, NHibernateUtil.String);
                    session.Flush();
                    return count >= 0 ? true : false;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public IList<ControlPoint> GetControlPointByCode(string code)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<ControlPoint> controlPoint = session.QueryOver<ControlPoint>().Where(c => c.Code == code).List();
                return controlPoint;
            }
        }

        public IList<ControlPoint> GetControlPointByRoom(string roomId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<ControlPoint> controlPoint = session.QueryOver<ControlPoint>().Where(c => c.Id_Device == roomId).List();
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
