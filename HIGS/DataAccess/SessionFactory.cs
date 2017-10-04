using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Model.Model;
using NHibernate;

namespace DataAccess
{
    public class SessionFactory
    {
        private static ISessionFactory session;

        public static ISessionFactory CreateSession()
        {

            if (session != null)
                return session;

            session = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2005.ConnectionString("Server=localhost\\SQLEXPRESS01;Database=master;Trusted_Connection=True;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProgramaDesconto>())
                //.Mappings(m => m.FluentMappings.Add<ProgramaDescontoMap>())
                .BuildSessionFactory();
            
            return session;

        }

        public static ISession OpenSession()
        {
            return CreateSession().OpenSession();
        }

    }
}
