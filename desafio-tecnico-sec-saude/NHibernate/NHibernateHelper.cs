using DesafioTecnicoSecSaude.Usuarios.Model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace DesafioTecnicoSecSaude.NHibernate
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory is null)
                {
                    string stringConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SecSaudeDb2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                    _sessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(stringConnection))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Usuario>())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Contato>())
                        .BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}