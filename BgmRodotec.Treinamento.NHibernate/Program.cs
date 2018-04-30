using System;
using System.Linq;
using BgmRodotec.Treinamento.NHibernate.Configuration;
using BgmRodotec.Treinamento.NHibernate.Models;
using BgmRodotec.Treinamento.NHibernate.Strategies;
using NHibernate.Linq;

namespace BgmRodotec.Treinamento.NHibernate
{
    class Program
    {
        static void Main(string[] args)
        {            
            try
            {
                var cmd = 0;
                var rand = new Random();
                PopulateData.Populate();                
                while (true)
                {
                    Console.WriteLine("Escolha a estratrégia: ");
                    Console.WriteLine("Linq");
                    Console.WriteLine("1 - Batch");
                    Console.WriteLine("2 - Eager (Funciona apenas com Collection do tipo ISet)\n");
                    
                    Console.WriteLine("QueryOver");
                    Console.WriteLine("3 - Batch");
                    Console.WriteLine("4 - Eager (Funciona apenas com Collection do tipo ISet)\n");
                    
                    Console.WriteLine("Hql");
                    Console.WriteLine("5 - Batch");
                    Console.WriteLine("6 - Eager (Funciona apenas com Collection do tipo ISet)\n");
                    var result = Console.ReadLine();

                    if (int.TryParse(result, out cmd))
                    {
                        if (cmd < 1)
                            break;
                        var id = rand.Next(1, 20);
                        switch (cmd)
                        {
                            case 1:
                                LinqStrategy.Batch(id);
                                break;
                            case 2:
                                LinqStrategy.EagerLoad(id);
                                break;
                            case 3:
                                QueryOverStrategy.Batch(id);
                                break;
                            case 4:
                                QueryOverStrategy.EagerLoad(id);
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