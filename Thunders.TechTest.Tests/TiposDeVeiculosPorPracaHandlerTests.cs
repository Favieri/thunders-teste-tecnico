using Moq;
using System.Threading.Tasks;
using Thunders.TechTest.ApiService.Handlers;
using Thunders.TechTest.ApiService.Interfaces;
using Xunit;

public class TiposDeVeiculosPorPracaHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCallRelatorioServiceMethod_WithPraca()
    {
        var mockRelatorioService = new Mock<IRelatorioService>();
        var handler = new TiposDeVeiculosPorPracaHandler(mockRelatorioService.Object);
        var praca = "Praca1";

        await handler.Handle(praca);

        mockRelatorioService.Verify(service => service.ObterTiposDeVeiculosPorPracaAsync(praca), Times.Once);
    }
}