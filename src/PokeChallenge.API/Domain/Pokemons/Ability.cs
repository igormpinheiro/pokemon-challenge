using ErrorOr;
using PokeChallenge.API.Domain.SharedKernel;

namespace PokeChallenge.API.Domain.Pokemons;

public sealed class Ability : Entity
{
    public bool IsMainSeries { get; private set; }
    public string Name { get; private set; }
    public ICollection<Effect> Effects { get; private set; }
    public ICollection<PokemonAbility> PokemonAbilities { get; private set; }

    private Ability()
    {
    }

    public static class Factory
    {
        public static ErrorOr<Ability> Create(bool isMainSeries, string name, ICollection<Effect> effects, ICollection<PokemonAbility> pokemonAbilities)
        {
            return new Ability
            {
                IsMainSeries = isMainSeries,
                Name = name,
                Effects = effects,
                PokemonAbilities = pokemonAbilities
            };
        }
    }
}
