using System;
using System.Linq;
using BgmRodotec.Treinamento.NHibernate.Configuration;
using BgmRodotec.Treinamento.NHibernate.Models;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate.SqlCommand;
using NHibernate.Util;

namespace BgmRodotec.Treinamento.NHibernate.Strategies
{
    public class CriteriaStrategy
    {
        public static void LazyLoad(long id)
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                var query = session.CreateCriteria<Pessoa>()
                    .Add(Restrictions.Eq("Id", id));
                Console.WriteLine(query.List().First());
            }
        }

        public static void Batch(long id)
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                var query = session.CreateCriteria<Pessoa>()
                    .Add(Restrictions.Eq("Id", id))
                    .Future<Pessoa>();

                session.CreateCriteria<Pessoa>("p")
                    .Add(Restrictions.Eq("Id", id))
                    .CreateCriteria("p.Enderecos", JoinType.LeftOuterJoin)
                    .Future<Pessoa>();

                session.CreateCriteria<Pessoa>("p")
                    .Add(Restrictions.Eq("Id", id))
                    .CreateCriteria("p.Telefones", "t", JoinType.LeftOuterJoin)
                    .CreateCriteria("t.TipoTelefone", "tt", JoinType.LeftOuterJoin)
                    .Future<Pessoa>();

                Console.WriteLine(query.ToList().First());
            }
        }

        public static void EagerLoad(long id)
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                var query = session.CreateCriteria<Pessoa>("p")
                    .Add(Restrictions.Eq("Id", id))
                    .CreateCriteria("p.Enderecos", JoinType.LeftOuterJoin)
                    .CreateCriteria("p.Telefones", "t", JoinType.LeftOuterJoin)
                    .CreateCriteria("t.TipoTelefone", "tt", JoinType.LeftOuterJoin);

                Console.WriteLine(query.List().First());
            }
        }
    }
}