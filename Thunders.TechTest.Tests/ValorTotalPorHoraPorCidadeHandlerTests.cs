using Moq;
using System.Threading.Tasks;
using Thunders.TechTest.ApiService.Handlers;
using Thunders.TechTest.ApiService.Interfaces;
using Thunders.TechTest.ApiService.Utils;
using Xunit;

public class ValorTotalPorHoraPorCidadeHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCallRelatorioServiceMethod()
    {
        var mockRelatorioService = new Mock<IRelatorioService>();
        var handler = new ValorTotalPorHoraPorCidadeHandler(mockRelatorioService.Object);

        await handler.Handle(new GerarRelatorioValorTotalPorHoraPorCidade());

        mockRelatorioService.Verify(service => service.ObterValorTotalPorHoraPorCidadeAsync(), Times.Once);
    }
}