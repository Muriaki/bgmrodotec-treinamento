using System;
using System.Linq;
using BgmRodotec.Treinamento.NHibernate.Configuration;
using BgmRodotec.Treinamento.NHibernate.Models;
using FluentNHibernate.Utils;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate.Transform;

namespace BgmRodotec.Treinamento.NHibernate.Strategies
{
    public class ExtraStrategy
    {
        public static void SessionGet(long id)
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                var query = session.Get<Pessoa>(id);
                Console.WriteLine(query);
            }
        }

        public static void PaginationWithQueryOverWithCollectionEagerFetch()
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                // Garante a sintaxe para execução da subquery
                var subQuery = QueryOver.Of<Pessoa>();

                var numberItens = 3;
                var pageNumber = 2 * numberItens;

                var pageSubQuery = subQuery.Clone()
                    .OrderBy(p => p.Id).Asc
                    .Select(p => p.Id)
                    .Skip(pageNumber) // Número da página
                    .Take(numberItens); // Quantidade de Itens por página

                var items = session.QueryOver<Pessoa>()
                    .WithSubquery.WhereProperty(p => p.Id).In(pageSubQuery)
                    .OrderBy(p => p.Id).Asc // Importante ter a mesma ordenação da subquery
                    .Fetch(p => p.Enderecos).Eager
                    .TransformUsing(new DistinctRootEntityResultTransformer())
                    .Future();
                
                // Quantidade de pessoas totais
                var count = subQuery.GetExecutableQueryOver(session)
                    .Select(Projections.CountDistinct<Pessoa>(p => p.Id))
                    .FutureValue<int>();

                Console.WriteLine($"\nQuantidade de pessoas totais : {count.Value}\n");
                
                foreach (var pessoa in items.ToList())
                {
                    Console.WriteLine($"Pessoa: {pessoa.Nome}");
                    Console.WriteLine($"Quantidade endreço: {pessoa.Enderecos.Count}");
                }
            }
        }
        
        public static void PaginationWithLinqWithCollectionEagerFetch()
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                var numberItens = 3;
                var pageNumber = 2 * numberItens;

                var pageSubQuery = session.Query<Pessoa>()
                    .OrderBy(p => p.Id)
                    .Select(p => p.Id)
                    .Skip(pageNumber) // Número da página
                    .Take(numberItens); // Quantidade de Itens por página

                var items = session.Query<Pessoa>()
                    .Where(w => pageSubQuery.Contains(w.Id))
                    .OrderBy(p => p.Id) // Importante ter a mesma ordenação da subquery
                    .FetchMany(p => p.Enderecos)                    
                    .ToFuture();
                
                /*
                 * Obs.: Qualquer filtro terá que ser repetida na subquery do count
                 *  e na na subquery da paginação!
                 */                
                // Quantidade de pessoas totais
                var count = session.Query<Pessoa>() 
                    .Select(p => p.Id)
                    .Distinct()
                    .ToFuture()
                    .Count();

                Console.WriteLine($"\nQuantidade de pessoas totais : {count}\n");
                
                foreach (var pessoa in items.ToList())
                {
                    Console.WriteLine($"Pessoa: {pessoa.Nome}");
                    Console.WriteLine($"Quantidade endreço: {pessoa.Enderecos.Count}");
                }
            }
        }
    }
}