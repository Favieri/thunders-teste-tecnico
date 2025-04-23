using Rebus.Handlers;
using Thunders.TechTest.ApiService.Interfaces;
using Thunders.TechTest.ApiService.Models;
using Thunders.TechTest.ApiService.Utils;

namespace Thunders.TechTest.ApiService.Handlers
{
    public class ValorTotalPorHoraPorCidadeHandler : IHandleMessages<GerarRelatorioValorTotalPorHoraPorCidade>
    {
        private readonly IRelatorioService _relatorioService;

        public ValorTotalPorHoraPorCidadeHandler(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        public async Task Handle(GerarRelatorioValorTotalPorHoraPorCidade message)
        {
            await _relatorioService.ObterValorTotalPorHoraPorCidadeAsync();

            Console.WriteLine("Relatório de Valor Total Por Hora Por Cidade gerado e persistido.");
        }
    }

    public class PracasMaisFaturaramPorMesHandler : IHandleMessages<int>
    {
        private readonly IRelatorioService _relatorioService;

        public PracasMaisFaturaramPorMesHandler(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        public async Task Handle(int quantidade)
        {
            if (quantidade <= 0)
                quantidade = 5;

            await _relatorioService.ObterPracasMaisFaturaramPorMesAsync(quantidade);
            Console.WriteLine("Relatório de Praças Mais Faturaram Por Mês gerado e persistido.");
        }
    }

    public class TiposDeVeiculosPorPracaHandler : IHandleMessages<string>
    {
        private readonly IRelatorioService _relatorioService;

        public TiposDeVeiculosPorPracaHandler(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        public async Task Handle(string praca)
        {
            await _relatorioService.ObterTiposDeVeiculosPorPracaAsync(praca);

            Console.WriteLine($"Relatório de Tipos de Veículos Por Praça ({praca}) gerado e persistido.");
        }
    }
}
