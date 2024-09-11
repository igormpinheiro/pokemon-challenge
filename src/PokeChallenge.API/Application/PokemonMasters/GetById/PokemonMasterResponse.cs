namespace PokeChallenge.API.Application.PokemonMasters.GetById;

internal sealed record PokemonMasterResponse
{
    public int Id { get; init; }
    public string Nome { get; init; }
    public string Email { get; init; }
    public string CPF { get; init; }
}
