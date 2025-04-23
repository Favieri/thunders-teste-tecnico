namespace Thunders.TechTest.ApiService.Models
{
    public class Relatorio
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TipoRelatorio { get; set; }
        public DateTime GeradoEm { get; set; }
        public string Conteudo { get; set; }
    }
}
