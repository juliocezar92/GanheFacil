namespace GanheFacil.Models
{
    public class Resultado
    {
        public int Id { get; set; }
        public DateTime DataSorteio { get; set; }
        public List<int> NumerosSorteados { get; set; }
        public decimal ValorPremio { get; set; }
    }
}
