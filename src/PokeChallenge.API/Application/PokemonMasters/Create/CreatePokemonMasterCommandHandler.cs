using ErrorOr;
using PokeChallenge.API.Application.Abstractions.Messaging;
using PokeChallenge.API.Domain.PokemonMasters;

namespace PokeChallenge.API.Application.PokemonMasters.Create;

public sealed class CreatePokemonMasterCommandHandler(IPokemonMasterRepository _repository) : ICommandHandler<CreatePokemonMasterCommand, int>
{
    public async Task<ErrorOr<int>> Handle(CreatePokemonMasterCommand request, CancellationToken cancellationToken)
    {
        var emailResult = Email.Create(request.Email);

        if (emailResult.IsError)
        {
            return emailResult.Errors;
        }

        var email = emailResult.Value;
        if (!await _repository.IsEmailUniqueAsync(email, cancellationToken))
        {
            return PokemonMasterErrors.EmailAlreadyExists();
        }

        var cpfResult = CPF.Create(request.CPF);
        if (cpfResult.IsError)
        {
            return cpfResult.Errors;
        }

        var pokemonMaster = PokemonMaster.Factory.Create(request.Nome, email, cpfResult.Value);

        if (pokemonMaster.IsError)
        {
            return pokemonMaster.Errors;
        }

        _repository.Insert(pokemonMaster.Value);

        return pokemonMaster.Value.Id;
    }
}
