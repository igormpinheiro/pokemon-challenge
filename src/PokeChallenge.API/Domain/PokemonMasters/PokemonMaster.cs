using ErrorOr;

namespace PokeChallenge.API.Domain.PokemonMasters;

public sealed class PokemonMaster
{
    public int Id { get; }
    public string Nome { get; private set; }
    public Email Email { get; private set; }
    public CPF CPF { get; private set; }

    private PokemonMaster()
    {
    }

    public static class Factory
    {
        public static ErrorOr<PokemonMaster> Create(string nome, Email email, CPF cpf)
        {
            return new PokemonMaster
            {
                Nome = nome,
                Email = email,
                CPF = cpf,
            };
        }
    }
}
