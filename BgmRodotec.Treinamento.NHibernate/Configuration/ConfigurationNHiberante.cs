using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace BgmRodotec.Treinamento.NHibernate.Configuration
{
    public class ConfigurationNHiberante
    {
        private static ISessionFactory _sessionFactory;

        public static ISession CreateSession()
        {
            if (_sessionFactory == null)
                _sessionFactory = CreateSessionFactory();
            return _sessionFactory.OpenSession();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c
                        .Server("localhost")
                        .Database("Treinamento")
                        .Username("sa")
                        .Password("bgm123"))
                    .ShowSql()
                    .FormatSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(global::NHibernate.Cfg.Configuration config)
        {
            var schemaExport = new SchemaExport(config);
            schemaExport.Drop(false, true);
            schemaExport.Create(false, true);
                        
        }
    }
}