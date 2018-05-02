namespace BgmRodotec.Treinamento.NHibernate.DataTransferObject
{
    public class TelefoneDto
    {
        public string Numero { get; set; }

        public override string ToString()
        {
            return Numero;
        }
    }
}