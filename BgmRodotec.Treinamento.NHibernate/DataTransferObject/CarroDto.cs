using System.Collections.Generic;

namespace BgmRodotec.Treinamento.NHibernate.DataTransferObject
{
    public class CarroDto
    {
        public string Modelo { get; set; }
        public ISet<PessoaDto> Pessoas { get; set; }
    }
}