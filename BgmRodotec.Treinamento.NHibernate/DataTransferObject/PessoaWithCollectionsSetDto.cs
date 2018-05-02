using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using NHibernate.Mapping.ByCode;

namespace BgmRodotec.Treinamento.NHibernate.DataTransferObject
{
    public class PessoaWithCollectionsSetDto
    {
        public string Nome { get; set; }
        public ISet<EnderecoDto> Enderecos { get; set; }
        public ISet<TelefoneDto> Telefones { get; set; }
        
        public override string ToString() 
        {
            var builder = new StringBuilder();
            builder.Append(string.Format("Nome : {0}", Nome));
            builder.Append("\n");
            builder.Append(string.Format("Enderecos : {0}", Enderecos.Count()));
            builder.Append("\n");
            builder.Append(string.Format("Numeros : {0}", Telefones.Count()));
            builder.Append("\n");
            return builder.ToString();
        }
    }
}