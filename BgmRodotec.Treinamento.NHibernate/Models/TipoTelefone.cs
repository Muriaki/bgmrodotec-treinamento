using System.ComponentModel;
using System.Text;
using FluentNHibernate.Data;

namespace BgmRodotec.Treinamento.NHibernate.Models
{
    public class TipoTelefone : Entity
    {
        public virtual string Tipo { get; set; }
        
        public override string ToString()
        {
            return Tipo;
        }
    }
}