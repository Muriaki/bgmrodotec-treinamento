using System.Collections.Generic;
using FluentNHibernate.Data;

namespace BgmRodotec.Treinamento.NHibernate.Models
{
    public class Endereco : Entity
    {        
        public virtual string Rua { get; set; }
        
        public virtual Pessoa Pessoa { get; set; }
        
        public override string ToString()
        {
            return Rua + "; ";
        }
    }
}