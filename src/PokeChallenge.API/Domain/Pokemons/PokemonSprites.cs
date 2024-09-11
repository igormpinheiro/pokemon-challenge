using ErrorOr;
using PokeChallenge.API.Domain.SharedKernel;

namespace PokeChallenge.API.Domain.Pokemons;

public sealed class PokemonSprites : ValueObject
{
    public string BackDefault { get; private set; }
    public string BackFemale { get; private set; }
    public string BackShiny { get; private set; }
    public string BackShinyFemale { get; private set; }
    public string FrontDefault { get; private set; }
    public string FrontFemale { get; private set; }
    public string FrontShiny { get; private set; }
    public string FrontShinyFemale { get; private set; }

    private PokemonSprites()
    {
    }

    public static class Factory
    {
        public static ErrorOr<PokemonSprites> Create(string backDefault, string backFemale, string backShiny, string backShinyFemale, string frontDefault, string frontFemale, string frontShiny, string frontShinyFemale)
        {
            return new PokemonSprites
            {
                BackDefault = backDefault,
                BackFemale = backFemale,
                BackShiny = backShiny,
                BackShinyFemale = backShinyFemale,
                FrontDefault = frontDefault,
                FrontFemale = frontFemale,
                FrontShiny = frontShiny,
                FrontShinyFemale = frontShinyFemale
            };
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return BackDefault;
        yield return BackFemale;
        yield return BackShiny;
        yield return BackShinyFemale;
        yield return FrontDefault;
        yield return FrontFemale;
        yield return FrontShiny;
        yield return FrontShinyFemale;
    }
}
