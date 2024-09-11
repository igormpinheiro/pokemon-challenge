using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeChallenge.API.Domain.Pokemons;

namespace PokeChallenge.API.Infra.Persistence.Configurations;

public class EffectConfig : IEntityTypeConfiguration<Effect>
{
    public void Configure(EntityTypeBuilder<Effect> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Description).IsRequired();
        builder.Property(e => e.ShortDescription).IsRequired();
        builder.HasOne(e => e.Ability).WithMany(a => a.Effects).HasForeignKey(e => e.AbilityId);
    }
}
