using Microsoft.EntityFrameworkCore;
using PokeChallenge.API;
using PokeChallenge.API.Application.Abstractions.Data;
using PokeChallenge.API.Config.Extensions;
using PokeChallenge.API.Domain.PokemonMasters;
using PokeChallenge.API.Infra.Persistence;
using PokeChallenge.API.Infra.Persistence.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IDbConnectionFactory>(_ => new DbConnectionFactory(builder.Configuration.GetConnectionString("DefaultConnection")!));
builder.Services.AddScoped<IPokemonMasterRepository, PokemonMasterRepository>();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(AssemblyReference.Assembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.MapControllers();

await app.RunAsync();

public partial class Program;
