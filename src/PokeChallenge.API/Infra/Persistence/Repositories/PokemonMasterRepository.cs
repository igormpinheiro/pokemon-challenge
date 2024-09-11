using Microsoft.EntityFrameworkCore;
using PokeChallenge.API.Domain.PokemonMasters;

namespace PokeChallenge.API.Infra.Persistence.Repositories;

public class PokemonMasterRepository(AppDbContext context) : IPokemonMasterRepository
{
    public Task<PokemonMaster?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return context.PokemonMasters.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken)
    {
        return !await context.PokemonMasters.AnyAsync(u => u.Email == email, cancellationToken);
    }

    public void Insert(PokemonMaster pokemonMaster)
    {
        context.Add(pokemonMaster);
        context.SaveChanges();
    }
}
