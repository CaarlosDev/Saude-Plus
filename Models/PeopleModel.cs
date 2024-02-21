namespace SaudePlus.Models
{
    public class PeopleModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int DtNascimento { get; set; }
        public string Sexo { get; set; }
        public string Cidade { get; set; }
        public bool SeFumante { get; set; }
        public int SefQuantidadeDia { get; set; }
    }
}