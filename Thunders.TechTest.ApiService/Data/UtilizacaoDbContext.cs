using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.ApiService.Models;

namespace Thunders.TechTest.ApiService.Data
{
    public class UtilizacaoDbContext : DbContext
    {
        public DbSet<Utilizacao> Utilizacoes { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }

        public UtilizacaoDbContext(DbContextOptions<UtilizacaoDbContext> options) : base(options) { }


    }
}
