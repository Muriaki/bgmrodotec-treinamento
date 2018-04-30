using BgmRodotec.Treinamento.NHibernate.Models;
using FluentNHibernate.Mapping;

namespace BgmRodotec.Treinamento.NHibernate.Mappings
{
    public class TelefoneMap : ClassMap<Telefone>
    {
        public TelefoneMap()
        {
            Table("Telefone");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Numero);
            
            References(x => x.Pessoa).Column("Id_Pessoa").Cascade.All().Not.LazyLoad();
            References(x => x.TipoTelefone).Column("Id_Tipo_Telefone").Cascade.All().Not.LazyLoad();
        }
    }
}