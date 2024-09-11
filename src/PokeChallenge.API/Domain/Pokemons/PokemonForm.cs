using ErrorOr;
using PokeChallenge.API.Domain.SharedKernel;

namespace PokeChallenge.API.Domain.Pokemons;

public sealed class PokemonForm : Entity
{
    public int Order { get; private set; }
    public string Name { get; private set; }
    public bool IsBattleOnly { get; private set; }
    public bool IsDefault { get; private set; }
    public bool IsMega { get; private set; }
    public int PokemonId { get; private set; }
    public Pokemon Pokemon { get; private set; }
    public PokemonSprites Sprites { get; private set; }

    private PokemonForm()
    {
    }

    public static class Factory
    {
        public static ErrorOr<PokemonForm> Create(int order, string name, bool isBattleOnly, bool isDefault, bool isMega, Pokemon pokemon, PokemonSprites sprites)
        {
            return new PokemonForm
            {
                Order = order,
                Name = name,
                IsBattleOnly = isBattleOnly,
                IsDefault = isDefault,
                IsMega = isMega,
                PokemonId = pokemon.Id,
                Pokemon = pokemon,
                Sprites = sprites
            };
        }
    }
}
