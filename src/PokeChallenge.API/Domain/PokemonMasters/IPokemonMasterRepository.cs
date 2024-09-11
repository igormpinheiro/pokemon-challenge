namespace PokeChallenge.API.Domain.PokemonMasters;

public interface IPokemonMasterRepository
{
    Task<PokemonMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken);

    void Insert(PokemonMaster pokemonMaster);
}
