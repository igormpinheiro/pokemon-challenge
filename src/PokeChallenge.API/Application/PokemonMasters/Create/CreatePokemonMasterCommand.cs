using PokeChallenge.API.Application.Abstractions.Messaging;

namespace PokeChallenge.API.Application.PokemonMasters.Create;

public sealed record CreatePokemonMasterCommand(string Nome, string Email, string CPF) : ICommand<int>;
