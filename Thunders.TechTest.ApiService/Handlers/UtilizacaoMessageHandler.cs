using Rebus.Handlers;
using Thunders.TechTest.ApiService.Interfaces;
using Thunders.TechTest.ApiService.Models;
using Thunders.TechTest.ApiService.Services;

namespace Thunders.TechTest.ApiService.Handlers
{
    public class UtilizacaoMessageHandler : IHandleMessages<Utilizacao>
    {
        private readonly IUtilizacaoService _utilizacaoService;

        public UtilizacaoMessageHandler(IUtilizacaoService utilizacaoService)
        {
            _utilizacaoService = utilizacaoService;
        }

        public async Task Handle(Utilizacao message)
        {
            Console.WriteLine($"Mensagem recebida: {message.Praca}, {message.Cidade}, {message.ValorPago}");

            await  _utilizacaoService.RegistrarUtilizacaoAsync(message);
        }
    }
}
