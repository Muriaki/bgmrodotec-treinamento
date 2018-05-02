using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Data;

namespace BgmRodotec.Treinamento.NHibernate.Models
{
    public class Carro : Entity
    {
        public virtual string Modelo { get; set; }
        public virtual ISet<Pessoa> Pessoas { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("\n");
            builder.Append(string.Format("    Modelo : {0}", Modelo));
            builder.Append("\n");
            builder.Append(string.Format("    Pessoas : {0}", Pessoas.Count()));
            builder.Append("\n");
            return builder.ToString();
        }
    }
}