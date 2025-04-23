namespace Thunders.TechTest.ApiService.Models
{
    public class Utilizacao
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DataHora { get; set; }
        public string Praca { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public decimal ValorPago { get; set; }
        public string TipoVeiculo { get; set; }
    }
}
