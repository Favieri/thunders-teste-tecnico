using Moq;
using System.Threading.Tasks;
using Thunders.TechTest.ApiService.Handlers;
using Thunders.TechTest.ApiService.Interfaces;
using Thunders.TechTest.ApiService.Models;
using Xunit;

public class UtilizacaoMessageHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCallUtilizacaoServiceMethod_WithCorrectMessage()
    {
        var mockUtilizacaoService = new Mock<IUtilizacaoService>();
        var handler = new UtilizacaoMessageHandler(mockUtilizacaoService.Object);

        var utilizacao = new Utilizacao
        {
            Id = Guid.NewGuid(),
            DataHora = DateTime.Now,
            Praca = "Praca1",
            Cidade = "São Paulo",
            Estado = "SP",
            ValorPago = 15.50m,
            TipoVeiculo = "Carro"
        };

        await handler.Handle(utilizacao);

        mockUtilizacaoService.Verify(service => service.RegistrarUtilizacaoAsync(utilizacao), Times.Once);
    }
}