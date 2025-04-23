using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.ApiService;
using Thunders.TechTest.ApiService.Data;
using Thunders.TechTest.ApiService.Interfaces;
using Thunders.TechTest.ApiService.Services;
using Thunders.TechTest.OutOfBox.Database;
using Thunders.TechTest.OutOfBox.Queues;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddControllers();

var features = Features.BindFromConfiguration(builder.Configuration);

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddScoped<IRelatorioService, RelatorioService>();
builder.Services.AddScoped<IUtilizacaoService, UtilizacaoService>();

if (features.UseMessageBroker)
{
    builder.Services.AddBus(builder.Configuration, new SubscriptionBuilder());
}

if (features.UseEntityFramework)
{
    builder.Services.AddSqlServerDbContext<UtilizacaoDbContext>(builder.Configuration);
}

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<UtilizacaoDbContext>();
    dbContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapDefaultEndpoints();

app.MapControllers();

app.Run();
