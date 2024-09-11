using ErrorOr;
using PokeChallenge.API.Domain.SharedKernel;

namespace PokeChallenge.API.Domain.Pokemons;

public sealed class PokemonHeldItem : Entity
{
    public int PokemonId { get; private set; }
    public Pokemon Pokemon { get; private set; }
    public int ItemId { get; private set; }
    public Item Item { get; private set; }
    public ItemRarity Rarity { get; private set; }

    private PokemonHeldItem()
    {
    }

    public static class Factory
    {
        public static ErrorOr<PokemonHeldItem> Create(Pokemon pokemon, Item item, ItemRarity rarity)
        {
            return new PokemonHeldItem
            {
                PokemonId = pokemon.Id,
                Pokemon = pokemon,
                ItemId = item.Id,
                Item = item,
                Rarity = rarity
            };
        }
    }
}
