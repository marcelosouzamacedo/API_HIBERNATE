using DataAccess.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using Model.Model;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace DataAccess
{
    public class SessionFactory
    {
        private static ISessionFactory session;

        public static ISessionFactory CreateSession()
        {

            if (session != null)
                return session;

            //session = Fluently.Configure()
            //    .Database(MsSqlConfiguration.MsSql2005.ConnectionString("Server=localhost\\SQLEXPRESS01;Database=master;Trusted_Connection=True;"))
            //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProgramaDesconto>())
            //    //.Mappings(m => m.FluentMappings.Add<ProgramaDescontoMap>())
            //    .BuildSessionFactory();

            FluentConfiguration cnf = Fluently.Configure(new NHibernate.Cfg.Configuration().SetProperty("nhb2dll", "none"))
                .Database(MsSqlConfiguration.MsSql2005.ConnectionString("Server=localhost\\SQLEXPRESS01;Database=master;Trusted_Connection=True;")
                .ShowSql()).ExposeConfiguration(x => new SchemaUpdate(x).Execute(false, true))
                //.Mappings(x => x.FluentMappings.Conventions.Setup(m => m.Add(AutoImport.Never())).AddFromAssemblyOf<ProgramaDesconto>());
                .Mappings(m => m.FluentMappings.Add<ProgramaDescontoMap>())
                .Mappings(m => m.FluentMappings.Add<ClienteMap>());
            session = cnf.BuildSessionFactory();

            return session;

        }

        public static ISession OpenSession()
        {
            return CreateSession().OpenSession();
        }

    }
}
