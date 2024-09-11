using ErrorOr;
using PokeChallenge.API.Domain.SharedKernel;

namespace PokeChallenge.API.Domain.Pokemons;

public class PokemonCries : ValueObject
{
    public string Latest { get; private set; }
    public string Legacy { get; private set; }

    private PokemonCries()
    {
    }

    public static class Factory
    {
        public static ErrorOr<PokemonCries> Create(string latest, string legacy)
        {
            return new PokemonCries
            {
                Latest = latest,
                Legacy = legacy
            };
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Latest;
        yield return Legacy;
    }
}
