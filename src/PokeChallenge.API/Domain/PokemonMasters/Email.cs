using System.ComponentModel.DataAnnotations;
using ErrorOr;
using PokeChallenge.API.Domain.SharedKernel;

namespace PokeChallenge.API.Domain.PokemonMasters;

public sealed class Email : ValueObject
{
    public string Value { get; set; }
    public bool IsValid => !string.IsNullOrWhiteSpace(Value) && new EmailAddressAttribute().IsValid(Value);

    private Email(string value)
    {
        Value = value;
    }

    private Email()
    {
    }

    public static ErrorOr<Email> Create(string value)
    {
        return new Email(value).ToErrorOr().FailIf(val => !val.IsValid, Error.Validation("Email.InvalidEmail", "O Email é inválido."));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
