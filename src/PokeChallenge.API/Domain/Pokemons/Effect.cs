using ErrorOr;
using PokeChallenge.API.Domain.SharedKernel;

namespace PokeChallenge.API.Domain.Pokemons;

public sealed class Effect : Entity
{
    public string Description { get; private set; }
    public string ShortDescription { get; private set; }
    public int AbilityId { get; private set; }
    public Ability Ability { get; private set; }

    private Effect()
    {
    }

    public static class Factory
    {
        public static ErrorOr<Effect> Create(string description, string shortDescription, Ability ability)
        {
            return new Effect
            {
                Description = description,
                ShortDescription = shortDescription,
                AbilityId = ability.Id,
                Ability = ability
            };
        }
    }
}
