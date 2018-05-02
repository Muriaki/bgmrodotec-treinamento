using System;
using System.Linq;
using BgmRodotec.Treinamento.NHibernate.Configuration;
using BgmRodotec.Treinamento.NHibernate.Models;
using NHibernate.Util;

namespace BgmRodotec.Treinamento.NHibernate.Strategies
{
    public class HqlStrategy
    {
        public static void LazyLoad(long id)
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                //Prepara a query
                var query = session.CreateQuery("from Pessoa p where p.Id = :id")
                    .SetParameter("id", id);
                
                Console.WriteLine(query.List().First());
            }
        }

        
        public static void Batch(long id)
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                //Prepara a query
                var query = session.CreateQuery("from Pessoa p where p.Id = :id")
                    .SetParameter("id", id)
                    .Future<Pessoa>();
                
                // Eager load na primeira lista
                session.CreateQuery(@"
                    from Pessoa p 
                    left join fetch p.Enderecos e 
                    where p.Id = :id")
                    .SetParameter("id", id)
                    .Future<Pessoa>();
                
                // Eager load na segunda lista
                session.CreateQuery(@"
                    from Pessoa p 
                    left join fetch p.Telefones t
                    left join fetch t.TipoTelefone tt
                    where p.Id = :id")
                    .SetParameter("id", id)
                    .Future<Pessoa>();
                
                Console.WriteLine(query.ToList().First());
            }
        }

        public static void EagerLoad(long id)
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                var query = session.CreateQuery(@"
                    from Pessoa p
                    left join fetch p.Enderecos e
                    left join fetch p.Telefones t
                    left join fetch t.TipoTelefone tt
                    where p.Id = :id")
                    .SetParameter("id", id)
                    .List<Pessoa>().First();

                Console.WriteLine(query);
            }
        }
    }
}