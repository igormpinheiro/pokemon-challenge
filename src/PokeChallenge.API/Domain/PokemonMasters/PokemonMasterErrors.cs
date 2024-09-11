using ErrorOr;

namespace PokeChallenge.API.Domain.PokemonMasters;

public static class PokemonMasterErrors
{
    public static Error NotFound() => Error.NotFound(
        code: "PokemonMaster.NotFound",
        description: "Mestre Pokémon não encontrado.");

    public static Error EmailAlreadyExists() => Error.Conflict(
        code: "PokemonMaster.EmailAlreadyExists",
        description: "Email já cadastrado.");
}
