using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeChallenge.API.Domain.Pokemons;

namespace PokeChallenge.API.Infra.Persistence.Configurations;

public class AbilityConfig : IEntityTypeConfiguration<Ability>
{
    public void Configure(EntityTypeBuilder<Ability> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.IsMainSeries).IsRequired();
        builder.Property(e => e.Name).IsRequired();
        builder.HasMany(e => e.Effects).WithOne(ef => ef.Ability).HasForeignKey(ef => ef.AbilityId);
        builder.HasMany(e => e.PokemonAbilities).WithOne(pa => pa.Ability).HasForeignKey(pa => pa.AbilityId);
    }
}
