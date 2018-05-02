using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BgmRodotec.Treinamento.NHibernate.Models;
using NHibernate.Mapping.ByCode;

namespace BgmRodotec.Treinamento.NHibernate.DataTransferObject
{
    public class PessoaWithManyToManySetDto
    {
        public string Nome { get; set; }
        public ISet<CarroDto> Carros { get; set; }
        
        public override string ToString() 
        {
            var builder = new StringBuilder();
            builder.Append(string.Format("Nome : {0}", Nome));
            builder.Append("\n");
            builder.Append(string.Format("Carros : {0}", Carros.Count()));
            builder.Append("\n");            
            return builder.ToString();
        }
    }
}