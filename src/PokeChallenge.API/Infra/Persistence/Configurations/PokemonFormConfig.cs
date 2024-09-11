using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeChallenge.API.Domain.Pokemons;

namespace PokeChallenge.API.Infra.Persistence.Configurations;

public class PokemonFormConfig : IEntityTypeConfiguration<PokemonForm>
{
    public void Configure(EntityTypeBuilder<PokemonForm> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Order).IsRequired();
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.IsBattleOnly).IsRequired();
        builder.Property(e => e.IsDefault).IsRequired();
        builder.Property(e => e.IsMega).IsRequired();
        builder.HasOne(e => e.Pokemon).WithMany(p => p.Forms).HasForeignKey(e => e.PokemonId);

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
    }
}
