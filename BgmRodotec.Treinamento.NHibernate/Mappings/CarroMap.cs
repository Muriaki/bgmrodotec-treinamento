using BgmRodotec.Treinamento.NHibernate.Models;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace BgmRodotec.Treinamento.NHibernate.Mappings
{
    public class CarroMap : ClassMap<Carro>
    {
        public CarroMap()
        {
            
            Table("Carro");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Modelo);

            HasManyToMany(x => x.Pessoas).Cascade.All().LazyLoad()/*.Fetch.Join()*/.Inverse().Table("PessoaCarro");
        }
    }
}