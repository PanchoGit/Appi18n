using Appi18n.Application.Data;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Appi18n.Web
{
    public class NhibernateConfig
    {
        public static ISessionFactory BuildSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012
                    .ConnectionString(_ => _.FromConnectionStringWithKey("default"))
                    )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NoteData>())
                .BuildSessionFactory();
        }
    }
}