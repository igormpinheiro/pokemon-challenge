using Microsoft.EntityFrameworkCore;
using PokeChallenge.API.Domain.PokemonMasters;

namespace PokeChallenge.API.Infra.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    #region DbSets

    public DbSet<PokemonMaster> PokemonMasters { get; set; }

    #endregion DbSets

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}
