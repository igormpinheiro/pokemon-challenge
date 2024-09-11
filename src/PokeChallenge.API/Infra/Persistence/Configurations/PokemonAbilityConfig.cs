using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeChallenge.API.Domain.Pokemons;

namespace PokeChallenge.API.Infra.Persistence.Configurations;

public class PokemonAbilityConfig : IEntityTypeConfiguration<PokemonAbility>
{
    public void Configure(EntityTypeBuilder<PokemonAbility> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.IsHidden).IsRequired();
        builder.Property(e => e.Slot).IsRequired();
        builder.HasOne(e => e.Pokemon).WithMany(p => p.Abilities).HasForeignKey(e => e.PokemonId);
        builder.HasOne(e => e.Ability).WithMany(a => a.PokemonAbilities).HasForeignKey(e => e.AbilityId);
    }
}
