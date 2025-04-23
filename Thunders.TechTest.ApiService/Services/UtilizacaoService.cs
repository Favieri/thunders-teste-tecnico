using Thunders.TechTest.ApiService.Data;
using Thunders.TechTest.ApiService.Interfaces;
using Thunders.TechTest.ApiService.Models;

namespace Thunders.TechTest.ApiService.Services
{
    public class UtilizacaoService : IUtilizacaoService
    {
        private readonly UtilizacaoDbContext _dbContext;

        public UtilizacaoService(UtilizacaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task RegistrarUtilizacaoAsync(Utilizacao utilizacao)
        {
            _dbContext.Utilizacoes.Add(utilizacao);
            await _dbContext.SaveChangesAsync();
        }
    }
}
