using Thunders.TechTest.ApiService.Models;

namespace Thunders.TechTest.ApiService.Interfaces
{
    public interface IUtilizacaoService
    {
        Task RegistrarUtilizacaoAsync(Utilizacao utilizacao);
    }
}
