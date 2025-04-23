using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.ApiService.Data;
using Thunders.TechTest.ApiService.Interfaces;
using Thunders.TechTest.ApiService.Models;

public class RelatorioService : IRelatorioService
{
    private readonly UtilizacaoDbContext _dbContext;

    public RelatorioService(UtilizacaoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<object>> ObterValorTotalPorHoraPorCidadeAsync()
    {
        var resultado = await _dbContext.Utilizacoes
            .GroupBy(u => new { u.DataHora.Date, u.DataHora.Hour, u.Cidade })
            .Select(g => new
            {
                Data = g.Key.Date,
                Hora = g.Key.Hour,
                Cidade = g.Key.Cidade,
                ValorTotal = g.Sum(u => u.ValorPago)
            })
            .ToListAsync();

        var conteudo = System.Text.Json.JsonSerializer.Serialize(resultado);

        var relatorio = new Relatorio
        {
            TipoRelatorio = "ValorTotalPorHoraPorCidade",
            Conteudo = conteudo
        };

        _dbContext.Relatorios.Add(relatorio);
        await _dbContext.SaveChangesAsync();

        return resultado;
    }

    public async Task<IEnumerable<object>> ObterPracasMaisFaturaramPorMesAsync(int quantidade)
    {
        var resultado = await _dbContext.Utilizacoes
            .GroupBy(u => new { u.DataHora.Year, u.DataHora.Month, u.Praca })
            .Select(g => new
            {
                Ano = g.Key.Year,
                Mes = g.Key.Month,
                Praca = g.Key.Praca,
                ValorTotal = g.Sum(u => u.ValorPago)
            })
            .OrderByDescending(g => g.ValorTotal)
            .Take(quantidade)
            .ToListAsync();

        var conteudo = System.Text.Json.JsonSerializer.Serialize(resultado);

        var relatorio = new Relatorio
        {
            TipoRelatorio = "PracasMaisFaturaramPorMes",
            Conteudo = conteudo
        };

        _dbContext.Relatorios.Add(relatorio);
        await _dbContext.SaveChangesAsync();

        return resultado;
    }

    public async Task<IEnumerable<object>> ObterTiposDeVeiculosPorPracaAsync(string praca)
    {
        var resultado = await _dbContext.Utilizacoes
            .Where(u => u.Praca == praca)
            .GroupBy(u => u.TipoVeiculo)
            .Select(g => new
            {
                TipoVeiculo = g.Key,
                Quantidade = g.Count()
            })
            .ToListAsync();

        var conteudo = System.Text.Json.JsonSerializer.Serialize(resultado);

        var relatorio = new Relatorio
        {
            TipoRelatorio = "TiposDeVeiculosPorPraca",
            Conteudo = conteudo
        };

        _dbContext.Relatorios.Add(relatorio);
        await _dbContext.SaveChangesAsync();

        return resultado;
    }
}
