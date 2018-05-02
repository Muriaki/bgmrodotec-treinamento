using BgmRodotec.Treinamento.NHibernate.Models;
using FluentNHibernate.Mapping;

namespace BgmRodotec.Treinamento.NHibernate.Mappings
{
    public class EnderecoMap : ClassMap<Endereco>
    {
        public EnderecoMap()
        {
            Table("Endereco");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Rua);
            
            References(x => x.Pessoa).Column("Id_Pessoa").Cascade.All()/*.Fetch.Join()*/.Not.LazyLoad();
        }
    }
}