using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FluentNHibernate.Data;

namespace BgmRodotec.Treinamento.NHibernate.Models
{
    public class Pessoa : Entity
    {
        public virtual string Nome { get; set; }

        public virtual ISet<Telefone> Telefones { get; set; }
        public virtual ISet<Endereco> Enderecos { get; set; }
        public virtual ISet<Carro> Carros { get; set; }

        public override string ToString()
        {
            var coll = TypeDescriptor.GetProperties(this);
            var builder = new StringBuilder();
            foreach (PropertyDescriptor pd in coll)
            {
                builder.Append(string.Format("{0} : {1}", pd.Name, pd.GetValue(this)?.ToString()));
                builder.Append("\n");
            }

            return builder.ToString();
        }
    }
}