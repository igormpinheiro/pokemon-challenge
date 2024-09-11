using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeChallenge.API.Domain.Pokemons;

namespace PokeChallenge.API.Infra.Persistence.Configurations;

public class ItemConfig : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Cost).IsRequired();
        builder.Property(e => e.FlingPower);
        builder.HasOne(e => e.Effect).WithMany().HasForeignKey(e => e.EffectId);
        builder.HasMany(e => e.Attributes).WithOne(a => a.Item).HasForeignKey(a => a.ItemId);
        builder.HasMany(e => e.PokemonHeldItems).WithOne(phi => phi.Item).HasForeignKey(phi => phi.ItemId);
    }
}
