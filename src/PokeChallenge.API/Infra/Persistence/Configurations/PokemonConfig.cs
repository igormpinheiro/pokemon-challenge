using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeChallenge.API.Domain.Pokemons;

namespace PokeChallenge.API.Infra.Persistence.Configurations;

public class PokemonConfig : IEntityTypeConfiguration<Pokemon>
{
    public void Configure(EntityTypeBuilder<Pokemon> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.BaseExperience).IsRequired();
        builder.Property(e => e.Height).IsRequired();
        builder.Property(e => e.IsDefault).IsRequired();
        builder.Property(e => e.Order).IsRequired();
        builder.Property(e => e.Weight).IsRequired();
        builder.Property(e => e.LocationAreaEncounters).IsRequired();

        builder.OwnsOne(e => e.Cries, cries =>
        {
            cries.Property(c => c.Latest).HasColumnName("CryLatest").IsRequired();
            cries.Property(c => c.Legacy).HasColumnName("CryLegacy").IsRequired();
        });

        builder.OwnsOne(e => e.Sprites, sprites =>
        {
            sprites.Property(s => s.FrontDefault).HasColumnName("SpriteFrontDefault").IsRequired();
            sprites.Property(s => s.FrontShiny).HasColumnName("SpriteFrontShiny").IsRequired();
            sprites.Property(s => s.FrontFemale).HasColumnName("SpriteFrontFemale").IsRequired();
            sprites.Property(s => s.FrontShinyFemale).HasColumnName("SpriteFrontShinyFemale").IsRequired();
            sprites.Property(s => s.BackDefault).HasColumnName("SpriteBackDefault").IsRequired();
            sprites.Property(s => s.BackShiny).HasColumnName("SpriteBackShiny").IsRequired();
            sprites.Property(s => s.BackFemale).HasColumnName("SpriteBackFemale").IsRequired();
            sprites.Property(s => s.BackShinyFemale).HasColumnName("SpriteBackShinyFemale").IsRequired();
        });

        builder.HasMany(e => e.Abilities).WithOne(a => a.Pokemon).HasForeignKey(a => a.PokemonId);
        builder.HasMany(e => e.Forms).WithOne(f => f.Pokemon).HasForeignKey(f => f.PokemonId);
        builder.HasMany(e => e.HeldItems).WithOne(h => h.Pokemon).HasForeignKey(h => h.PokemonId);
    }
}
