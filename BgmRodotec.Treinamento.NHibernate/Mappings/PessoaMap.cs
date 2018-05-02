using BgmRodotec.Treinamento.NHibernate.Models;
using FluentNHibernate.Mapping;

namespace BgmRodotec.Treinamento.NHibernate.Mappings
{
    public class PessoaMap : ClassMap<Pessoa>
    {
        public PessoaMap()
        {
            Table("Pessoa");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome);
            
            HasMany(x => x.Telefones).Cascade.All().LazyLoad().Inverse().KeyColumn("Id_Pessoa");
            HasMany(x => x.Enderecos).Cascade.All().LazyLoad().Inverse().KeyColumn("Id_Pessoa");
            
            HasManyToMany(x => x.Carros).Cascade.All().LazyLoad().Table("PessoaCarro");
        }
    }
}