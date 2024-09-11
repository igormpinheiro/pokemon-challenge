using Microsoft.EntityFrameworkCore;
using PokeChallenge.API.Domain.PokemonMasters;
using PokeChallenge.API.Domain.Pokemons;

namespace PokeChallenge.API.Infra.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    #region DbSets

    public DbSet<PokemonMaster> PokemonMasters { get; set; }
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<PokemonAbility> PokemonAbilities { get; set; }
    public DbSet<PokemonForm> PokemonForms { get; set; }
    public DbSet<PokemonHeldItem> PokemonHeldItems { get; set; }
    public DbSet<Ability> Abilities { get; set; }
    public DbSet<Effect> Effects { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemAttribute> ItemAttributes { get; set; }

    #endregion DbSets

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}
