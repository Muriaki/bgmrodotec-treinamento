using System.ComponentModel;
using System.Text;

namespace BgmRodotec.Treinamento.NHibernate.DataTransferObject
{
    public class PessoaDto
    {
        public string Nome { get; set; }
        
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