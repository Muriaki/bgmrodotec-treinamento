using System.ComponentModel;
using System.Text;

namespace BgmRodotec.Treinamento.NHibernate.DataTransferObject
{
    public class PessoaEnderecoTelefoneTipoDto
    {
        public string Nome { get; set; }
        public string Rua { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
        
        public override string ToString() 
        {
            var coll = TypeDescriptor.GetProperties(this);
            var builder = new StringBuilder();
            foreach(PropertyDescriptor pd in coll)
            {
                builder.Append(string.Format("{0} : {1}", pd.Name , pd.GetValue(this)?.ToString()));
                builder.Append("\n");
            }
            return builder.ToString();
        }
    }
}