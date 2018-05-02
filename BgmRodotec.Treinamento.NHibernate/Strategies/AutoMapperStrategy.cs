using System;
using System.Linq;
using AutoMapper.QueryableExtensions;
using BgmRodotec.Treinamento.NHibernate.Configuration;
using BgmRodotec.Treinamento.NHibernate.DataTransferObject;
using BgmRodotec.Treinamento.NHibernate.Models;

namespace BgmRodotec.Treinamento.NHibernate.Strategies
{
    public class AutoMapperStrategy
    {
        public static void PessoaEnderecoTelefoneTipo(long id)
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                var query = session.Query<Pessoa>()
                    .Where(p => p.Id == id)
                    .ProjectTo<PessoaEnderecoTelefoneTipoDto>();

                Console.WriteLine(query.ToList().First());
            }
        }
        
        public static void Pessoa(int id)
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                var query = session.Query<Pessoa>()
                    .Where(p => p.Id == id)
                    .ProjectTo<PessoaDto>();

                Console.WriteLine(query.ToList().First());
            }
        }
        
        public static void PessoaWithCollectionsSet(long id)
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                var query = session.Query<Pessoa>()
                    .Where(p => p.Id == id)
                    .ProjectTo<PessoaWithCollectionsSetDto>();

                Console.WriteLine(query.ToList().First());
            }
        }
        
        public static void PessoaWithManyToManySet(long id)
        {
            using (var session = ConfigurationNHiberante.CreateSession())
            {
                var query = session.Query<Pessoa>()
                    .Where(p => p.Id == id)
                    .ProjectTo<PessoaWithManyToManySetDto>();

                Console.WriteLine(query.ToList().First());
            }
        }
        
    }
}