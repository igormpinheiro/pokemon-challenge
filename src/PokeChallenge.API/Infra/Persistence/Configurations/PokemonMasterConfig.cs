using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeChallenge.API.Domain.PokemonMasters;

namespace PokeChallenge.API.Infra.Persistence.Configurations;

public class PokemonMasterConfig : IEntityTypeConfiguration<PokemonMaster>
{
    public void Configure(EntityTypeBuilder<PokemonMaster> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(e => e.Nome).IsRequired();

        builder.ComplexProperty(
            u => u.Email,
            b => b.Property(e => e.Value)
            .HasColumnName("Email")
            .IsRequired());

        builder.ComplexProperty(
            u => u.CPF,
            b => b.Property(e => e.Value).HasColumnName("Cpf"));
    }
}
