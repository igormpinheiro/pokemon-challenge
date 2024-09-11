using ErrorOr;
using PokeChallenge.API.Domain.PokemonMasters;
using PokeChallenge.API.Domain.SharedKernel;

namespace PokeChallenge.API.Domain.Pokemons;

public sealed class Pokemon : Entity
{
    public string Name { get; private set; }
    public int BaseExperience { get; private set; }
    public int Height { get; private set; }
    public bool IsDefault { get; private set; }
    public int Order { get; private set; }
    public int Weight { get; private set; }
    public string LocationAreaEncounters { get; private set; }
    public PokemonCries Cries { get; private set; }
    public PokemonSprites Sprites { get; private set; }
    public ICollection<PokemonAbility> Abilities { get; private set; } = [];
    public ICollection<PokemonForm> Forms { get; private set; } = [];
    public ICollection<PokemonHeldItem> HeldItems { get; private set; } = [];
    public int? PokemonMasterId { get; private set; }
    public PokemonMaster? PokemonMaster { get; private set; }

    private Pokemon()
    {
    }

    public void CaptureBy(PokemonMaster pokemonMaster)
    {
        PokemonMaster = pokemonMaster;
        PokemonMasterId = pokemonMaster.Id;
    }

    public class Builder
    {
        private readonly Pokemon _pokemon = new();

        public Builder WithName(string name)
        {
            _pokemon.Name = name;
            return this;
        }

        public Builder WithBaseExperience(int baseExperience)
        {
            _pokemon.BaseExperience = baseExperience;
            return this;
        }

        public Builder WithHeight(int height)
        {
            _pokemon.Height = height;
            return this;
        }

        public Builder IsDefault(bool isDefault = true)
        {
            _pokemon.IsDefault = isDefault;
            return this;
        }

        public Builder WithOrder(int order)
        {
            _pokemon.Order = order;
            return this;
        }

        public Builder WithWeight(int weight)
        {
            _pokemon.Weight = weight;
            return this;
        }

        public Builder WithAbilities(ICollection<PokemonAbility> abilities)
        {
            _pokemon.Abilities = abilities;
            return this;
        }

        public Builder WithCries(PokemonCries cries)
        {
            _pokemon.Cries = cries;
            return this;
        }

        public Builder WithForms(ICollection<PokemonForm> forms)
        {
            _pokemon.Forms = forms;
            return this;
        }

        public Builder WithHeldItems(ICollection<PokemonHeldItem> heldItems)
        {
            _pokemon.HeldItems = heldItems;
            return this;
        }

        public Builder WithLocationAreaEncounters(string locationAreaEncounters)
        {
            _pokemon.LocationAreaEncounters = locationAreaEncounters;
            return this;
        }

        public Builder WithSprites(PokemonSprites sprites)
        {
            _pokemon.Sprites = sprites;
            return this;
        }

        public Builder WithPokemonMaster(PokemonMaster pokemonMaster)
        {
            _pokemon.PokemonMaster = pokemonMaster;
            _pokemon.PokemonMasterId = pokemonMaster.Id;
            return this;
        }

        public ErrorOr<Pokemon> Build()
        {
            return _pokemon;
        }
    }
}
