using Thunders.TechTest.ApiService.Models;

namespace Thunders.TechTest.ApiService.Interfaces
{
    public interface IRelatorioService
    {
        Task<IEnumerable<object>> ObterValorTotalPorHoraPorCidadeAsync();
        Task<IEnumerable<object>> ObterPracasMaisFaturaramPorMesAsync(int quantidade);
        Task<IEnumerable<object>> ObterTiposDeVeiculosPorPracaAsync(string praca);
    }
}