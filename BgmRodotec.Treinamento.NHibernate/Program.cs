using System;
using BgmRodotec.Treinamento.NHibernate.Configuration;
using BgmRodotec.Treinamento.NHibernate.Strategies;

namespace BgmRodotec.Treinamento.NHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ConfigureAutoMapper.Configure();

                var cmd = 0;
                var rand = new Random();
                PopulateData.Populate();
                while (true)
                {
                    Console.WriteLine("Escolha a estratrégia: ");
                    Console.WriteLine("Linq");
                    Console.WriteLine("1 - Batch");
                    Console.WriteLine("2 - Eager Load (Funciona apenas com Collection do tipo ISet)");
                    Console.WriteLine("3 - Lazy Load\n");

                    Console.WriteLine("QueryOver");
                    Console.WriteLine("4 - Batch");
                    Console.WriteLine("5 - Eager Load (Funciona apenas com Collection do tipo ISet)");
                    Console.WriteLine("6 - Lazy Load\n");

                    Console.WriteLine("Hql");
                    Console.WriteLine("7 - Batch");
                    Console.WriteLine("8 - Eager Load (Funciona apenas com Collection do tipo ISet)");
                    Console.WriteLine("9 - Lazy Load\n");
                    
                    Console.WriteLine("Criteria (Estratégias Fetch no mapeamento funcionam nesse caso)");
                    Console.WriteLine("10 - Batch");
                    Console.WriteLine("11 - Eager Load (Funciona apenas com Collection do tipo ISet)");
                    Console.WriteLine("12 - Lazy Load\n");

                    Console.WriteLine("AutoMapper");
                    Console.WriteLine("13 - Mapper para Nome, Rua, Numero, Tipo");
                    Console.WriteLine("14 - Mapper para Nome");
                    Console.WriteLine("15 - Mapper para 2 listas");
                    Console.WriteLine("16 - Mapper para 1 listas Many to Many\n");
                    
                    Console.WriteLine("Extra");
                    Console.WriteLine("17 - Get in Session\n");


                    var result = Console.ReadLine();

                    if (int.TryParse(result, out cmd))
                    {
                        if (cmd < 1)
                            break;
                        var id = rand.Next(1, 10);
                        switch (cmd)
                        {
                            case 1:
                                LinqStrategy.Batch(id);
                                break;
                            case 2:
                                LinqStrategy.EagerLoad(id);
                                break;
                            case 3:
                                LinqStrategy.LazyLoad(id);
                                break;
                            case 4:
                                QueryOverStrategy.Batch(id);
                                break;
                            case 5:
                                QueryOverStrategy.EagerLoad(id);
                                break;
                            case 6:
                                QueryOverStrategy.LazyLoad(id);
                                break;
                            case 7:
                                HqlStrategy.Batch(id);
                                break;
                            case 8:
                                HqlStrategy.EagerLoad(id);
                                break;
                            case 9:
                                HqlStrategy.LazyLoad(id);
                                break;
                            case 10:
                                CriteriaStrategy.Batch(id);
                                break;
                            case 11:
                                CriteriaStrategy.EagerLoad(id);
                                break;
                            case 12:
                                CriteriaStrategy.LazyLoad(id);
                                break;
                            case 13:
                                AutoMapperStrategy.PessoaEnderecoTelefoneTipo(id);
                                break;
                            case 14:
                                AutoMapperStrategy.Pessoa(id);
                                break;
                            case 15:
                                AutoMapperStrategy.PessoaWithCollectionsSet(id);
                                break;
                            case 16:
                                AutoMapperStrategy.PessoaWithManyToManySet(id);
                                break;
                            case 17:
                                ExtrasStrategy.SessionGet(id);
                                break;
                            default:
                                Console.WriteLine("Nenhuma opção selecionada");
                                break;
                        }
                    }
                    else
                    {
                        break;
                    }

                    Console.WriteLine("Tecle qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}