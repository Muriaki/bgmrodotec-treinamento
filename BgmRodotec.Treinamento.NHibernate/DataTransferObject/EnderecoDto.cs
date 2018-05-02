namespace BgmRodotec.Treinamento.NHibernate.DataTransferObject
{
    public class EnderecoDto
    {
        public string Rua { get; set; }

        public override string ToString()
        {
            return Rua;
        }
    }
}