using ErrorOr;
using PokeChallenge.API.Domain.SharedKernel;

namespace PokeChallenge.API.Domain.Pokemons;

public class PokemonAbility : Entity
{
    public int PokemonId { get; private set; }
    public bool IsHidden { get; private set; }
    public int Slot { get; private set; }
    public Pokemon Pokemon { get; private set; }
    public int AbilityId { get; private set; }
    public Ability Ability { get; private set; }

    private PokemonAbility()
    {
    }

    public static class Factory
    {
        public static ErrorOr<PokemonAbility> Create(Pokemon pokemon, Ability ability, bool isHidden, int slot)
        {
            return new PokemonAbility
            {
                PokemonId = pokemon.Id,
                Pokemon = pokemon,
                AbilityId = ability.Id,
                Ability = ability,
                IsHidden = isHidden,
                Slot = slot
            };
        }
    }
}
