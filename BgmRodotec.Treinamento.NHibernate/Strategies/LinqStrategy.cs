using System;
using System.Linq;
using BgmRodotec.Treinamento.NHibernate.Configuration;
using BgmRodotec.Treinamento.NHibernate.Models;
using NHibernate.Linq;

namespace BgmRodotec.Treinamento.NHibernate.Strategies
{
    public class LinqStrategy
    {
        public static void Errado(int id)
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                var query = session.Query<Pessoa>()
                    .Where(pessoa => pessoa.Id == id);
                Console.WriteLine(query.ToList().First());
            }
        }
        
        public static void Batch(int id)
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                var query = session.Query<Pessoa>()
                    .Where(pessoa => pessoa.Id == id);

                query.FetchMany(pessoa => pessoa.Enderecos).ToFuture();
                
                query.FetchMany(pessoa => pessoa.Telefones)
                    .ThenFetch(telefone => telefone.TipoTelefone).ToFuture();
                
                query.FetchMany(pessoa => pessoa.Carros)
                        .ThenFetchMany(carro => carro.Pessoas).ToFuture();

                Console.WriteLine(query.ToFuture().ToList().First());
            }
        }

        public static void EagerLoad(int id)
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                var query = session.Query<Pessoa>()
                    .FetchMany(pessoa => pessoa.Enderecos)
                    .FetchMany(pessoa => pessoa.Telefones)
                        .ThenFetch(telefone => telefone.TipoTelefone)
                    .FetchMany(pessoa => pessoa.Carros)
                        .ThenFetchMany(carro => carro.Pessoas)
                    .Where(pessoa => pessoa.Id == id)
                    .ToList().First();

                Console.WriteLine(query);
            }
        }
    }
}