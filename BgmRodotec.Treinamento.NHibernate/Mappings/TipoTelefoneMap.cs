using BgmRodotec.Treinamento.NHibernate.Models;
using FluentNHibernate.Mapping;

namespace BgmRodotec.Treinamento.NHibernate.Mappings
{
    public class TipoTelefoneMap : ClassMap<TipoTelefone>
    {
        public TipoTelefoneMap()
        {
            Table("TipoTelefone");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Tipo);            
        }
    }
}