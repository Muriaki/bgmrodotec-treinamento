using System;
using System.Collections.Generic;
using BgmRodotec.Treinamento.NHibernate.Models;

namespace BgmRodotec.Treinamento.NHibernate.Configuration
{
    public class PopulateData
    {
        public static void Populate()
        {
            var random = new Random();

            using (var session = ConfigurationNHiberante.CreateSession())
            using (var transation = session.BeginTransaction())
            {
                var movel = new TipoTelefone {Tipo = "Movel"};
                var fixo = new TipoTelefone {Tipo = "Fixo"};

                session.Save(fixo);
                session.Save(movel);

                for (var i = 1; i <= 20; i++)
                {
                    var pessoa = new Pessoa()
                    {
                        Nome = "Pessoa - " + i
                    };

                    var listTelefone = new List<Telefone>(20);
                    var listEndereco = new List<Endereco>(20);

                    var telRandNum = random.Next(2, 5);
                    for (var j = 1; j <= telRandNum; j++)
                    {
                        var tipoRandNum = random.Next(1, 2);
                        var telefone = new Telefone()
                        {
                            Numero = "Numero - " + j,
                            Pessoa = pessoa,
                            TipoTelefone = tipoRandNum == 1 ? movel : fixo
                        };
                        listTelefone.Add(telefone);
                    }
                    
                    var endRandNum = random.Next(2, 5);
                    for (var j = 1; j <= endRandNum; j++)
                    {
                        var endereco = new Endereco()
                        {
                            Rua = "Rua - " + j,
                            Pessoa = pessoa
                        };
                        listEndereco.Add(endereco);
                    }
                    session.Save(pessoa);
                    foreach (var endereco in listEndereco)
                    {
                        session.Save(endereco);
                    }

                    foreach (var telefone in listTelefone)
                    {
                        session.Save(telefone);
                    }
                }

                transation.Commit();
            }
            Console.Clear();
        }
    }
}