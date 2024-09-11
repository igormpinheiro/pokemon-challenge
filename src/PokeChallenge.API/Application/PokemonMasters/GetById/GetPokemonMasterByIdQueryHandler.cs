using ErrorOr;
using PokeChallenge.API.Application.Abstractions.Messaging;
using PokeChallenge.API.Domain.PokemonMasters;

namespace PokeChallenge.API.Application.PokemonMasters.GetById;

internal sealed class GetPokemonMasterByIdQueryHandler(IPokemonMasterRepository _repository) : IQueryHandler<GetPokemonMasterByIdQuery, PokemonMasterResponse>
{
    public async Task<ErrorOr<PokemonMasterResponse>> Handle(GetPokemonMasterByIdQuery query, CancellationToken cancellationToken)
    {
        var pokemonMaster = await _repository.GetByIdAsync(query.Id, cancellationToken);

        if (pokemonMaster is null)
        {
            return PokemonMasterErrors.NotFound();
        }

        return new PokemonMasterResponse
        {
            Id = pokemonMaster.Id,
            Nome = pokemonMaster.Nome,
            Email = pokemonMaster.Email.Value,
            CPF = pokemonMaster.CPF.Value
        };
    }
}
