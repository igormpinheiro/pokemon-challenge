using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeChallenge.API.Domain.Pokemons;

namespace PokeChallenge.API.Infra.Persistence.Configurations;

public class PokemonHeldItemConfig : IEntityTypeConfiguration<PokemonHeldItem>
{
    public void Configure(EntityTypeBuilder<PokemonHeldItem> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Rarity).IsRequired();
        builder.HasOne(e => e.Pokemon).WithMany(p => p.HeldItems).HasForeignKey(e => e.PokemonId);
        builder.HasOne(e => e.Item).WithMany(i => i.PokemonHeldItems).HasForeignKey(e => e.ItemId);
    }
}
