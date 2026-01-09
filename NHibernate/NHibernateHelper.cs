using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.NHibernate;
using ISession = NHibernate.ISession;

public static class NHibernateHelper
{
    private static ISessionFactory _sessionFactory;

    public static ISessionFactory SessionFactory
    {
        get
        {
            if (_sessionFactory == null)
            {
                string connectionString = @"Server=192.168.44.242,1433;Database=Roflanizator;User Id=dockerUser;Password=strongPassword;TrustServerCertificate=True;";
                Console.WriteLine($"Conn: {connectionString}");
                var cfg = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                        .ConnectionString(connectionString)
                        .Driver<NHibernate.Driver.SqlClientDriver>()
                        .ShowSql())
                    .Mappings(m => m.FluentMappings
                        .AddFromAssemblyOf<CommodityMap>()
                        .AddFromAssemblyOf<BillMap>()
                        .AddFromAssemblyOf<CashierMap>()
                        .AddFromAssemblyOf<KkmMap>()
                        .AddFromAssemblyOf<ShiftMap>()
                        .AddFromAssemblyOf<ClientMap>()
                        .AddFromAssemblyOf<CounterMap>())
                    .BuildConfiguration();

                var update = new SchemaUpdate(cfg);

                update.Execute(true, true);

                _sessionFactory = cfg.BuildSessionFactory();
            }

            return _sessionFactory;
        }
    }

    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }
}
