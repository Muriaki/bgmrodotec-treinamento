using System;
using BgmRodotec.Treinamento.NHibernate.Configuration;
using BgmRodotec.Treinamento.NHibernate.Models;

namespace BgmRodotec.Treinamento.NHibernate.Strategies
{
    public class ExtrasStrategy
    {
        public static void SessionGet(long id)
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                var query = session.Get<Pessoa>(id);
                Console.WriteLine(query);
            }
        }
    }
}