using ErrorOr;
using PokeChallenge.API.Domain.SharedKernel;

namespace PokeChallenge.API.Domain.Pokemons;

public sealed class ItemAttribute : Entity
{
    public string Name { get; private set; }
    public int ItemId { get; private set; }
    public Item Item { get; private set; }

    private ItemAttribute()
    {
    }

    public static class Factory
    {
        public static ErrorOr<ItemAttribute> Create(string name, Item item)
        {
            return new ItemAttribute
            {
                Name = name,
                ItemId = item.Id,
                Item = item
            };
        }
    }
}
