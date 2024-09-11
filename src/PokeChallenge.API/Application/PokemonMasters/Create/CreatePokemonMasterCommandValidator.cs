using FluentValidation;

namespace PokeChallenge.API.Application.PokemonMasters.Create;

internal sealed class CreatePokemonMasterCommandValidator : AbstractValidator<CreatePokemonMasterCommand>
{
    public CreatePokemonMasterCommandValidator()
    {
        RuleFor(c => c.Nome)
            .NotEmpty();

        RuleFor(c => c.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(c => c.CPF)
            .NotEmpty()
            .Length(11);
    }
}
