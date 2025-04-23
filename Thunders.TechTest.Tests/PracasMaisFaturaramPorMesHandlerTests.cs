using Moq;
using System.Threading.Tasks;
using Thunders.TechTest.ApiService.Handlers;
using Thunders.TechTest.ApiService.Interfaces;
using Xunit;

public class PracasMaisFaturaramPorMesHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCallRelatorioServiceMethod_WithDefaultQuantity()
    {
        var mockRelatorioService = new Mock<IRelatorioService>();
        var handler = new PracasMaisFaturaramPorMesHandler(mockRelatorioService.Object);

        await handler.Handle(0); // Passando 0 para testar o valor padrão

        mockRelatorioService.Verify(service => service.ObterPracasMaisFaturaramPorMesAsync(5), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldCallRelatorioServiceMethod_WithCustomQuantity()
    {
        var mockRelatorioService = new Mock<IRelatorioService>();
        var handler = new PracasMaisFaturaramPorMesHandler(mockRelatorioService.Object);

        await handler.Handle(10); // Passando 10 como quantidade

        mockRelatorioService.Verify(service => service.ObterPracasMaisFaturaramPorMesAsync(10), Times.Once);
    }
}