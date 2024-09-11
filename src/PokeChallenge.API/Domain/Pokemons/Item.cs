using ErrorOr;
using PokeChallenge.API.Domain.SharedKernel;

namespace PokeChallenge.API.Domain.Pokemons;

public sealed class Item : Entity
{
    public string Name { get; private set; }
    public int Cost { get; private set; }
    public int? FlingPower { get; private set; }
    public int EffectId { get; private set; }
    public Effect Effect { get; private set; }
    public ICollection<ItemAttribute> Attributes { get; private set; } = [];
    public ICollection<PokemonHeldItem> PokemonHeldItems { get; private set; } = [];

    private Item()
    {
    }

    public static class Factory
    {
        public static ErrorOr<Item> Create(string name, int cost, int? flingPower, Effect effect, ICollection<ItemAttribute> attributes)
        {
            return new Item
            {
                Name = name,
                Cost = cost,
                FlingPower = flingPower,
                EffectId = effect.Id,
                Effect = effect,
                Attributes = attributes,
            };
        }
    }

    public void AddAttribute(ItemAttribute attribute)
    {
        Attributes.Add(attribute);
    }

    public void AddPokemonHeldItem(PokemonHeldItem pokemonHeldItem)
    {
        PokemonHeldItems.Add(pokemonHeldItem);
    }
}
