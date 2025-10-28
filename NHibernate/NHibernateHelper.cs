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
                var cfg = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                        .ConnectionString(@"Server=dpopov\ROFLANIZATOR;Database=Roflanizator;Integrated Security=True;")
                        .Driver<NHibernate.Driver.SqlClientDriver>()
                        .ShowSql())
                    .Mappings(m => m.FluentMappings
                        .AddFromAssemblyOf<CommodityMap>()
                        .AddFromAssemblyOf<BillMap>()
                        .AddFromAssemblyOf<CashierMap>()
                        .AddFromAssemblyOf<KkmMapper>()
                        .AddFromAssemblyOf<ShiftMapper>())
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
