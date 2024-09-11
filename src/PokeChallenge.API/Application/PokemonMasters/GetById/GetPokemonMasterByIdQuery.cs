using PokeChallenge.API.Application.Abstractions.Messaging;

namespace PokeChallenge.API.Application.PokemonMasters.GetById;

internal sealed record GetPokemonMasterByIdQuery(int Id) : IQuery<PokemonMasterResponse>;
