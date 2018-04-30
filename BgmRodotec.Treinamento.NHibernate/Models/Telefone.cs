using System.Collections.Generic;
using FluentNHibernate.Data;

namespace BgmRodotec.Treinamento.NHibernate.Models
{
    public class Telefone : Entity
    {
        public virtual string Numero { get; set; }
        
        public virtual Pessoa Pessoa { get; set; }
        public virtual TipoTelefone TipoTelefone { get; set; }
        
        public override string ToString()
        {
            return TipoTelefone + " - " + Numero + "; ";
        }
    }
}