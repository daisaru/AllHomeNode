using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace AllHomeNode.Database
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        //测试环境
        //public static string Conn = "Data Source=115.159.78.40;Database='allhome';User Id='sa';Password='woodhorse2';charset='utf8';pooling=true;SslMode=None";   // 测试环境
        //生产环境
        public static string Conn = "Data Source=115.159.72.249;Database='allhome';User Id='sa';Password='!Qw2#Er4%Ty6&Ui8';charset='utf8';pooling=true;SslMode=None";  // 生产环境

        private static void InitSessionFactory()
        {
            FluentConfiguration fluentConfiguration = Fluently.Configure();
            MySQLConfiguration mysqlConfiguration = MySQLConfiguration.Standard;
            mysqlConfiguration.ConnectionString(Conn);
            fluentConfiguration.Database(mysqlConfiguration);
            fluentConfiguration.Mappings(x => x.FluentMappings.AddFromAssemblyOf<NHibernateHelper>());
            _sessionFactory = fluentConfiguration.BuildSessionFactory();
        }

        private static ISessionFactory  SessionFactory
        {
            get
            {
                if(_sessionFactory == null)
                {
                    InitSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
