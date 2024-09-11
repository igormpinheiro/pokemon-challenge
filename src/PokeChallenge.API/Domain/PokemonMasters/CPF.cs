using System.Globalization;
using ErrorOr;
using PokeChallenge.API.Domain.SharedKernel;

namespace PokeChallenge.API.Domain.PokemonMasters;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "Sigla")]
public sealed class CPF : ValueObject
{
    public string Value { get; set; }
    public bool IsValid => ValidateCPF(Value);

    private CPF(string value)
    {
        Value = value;
    }

    private CPF()
    {
    }

    public static ErrorOr<CPF> Create(string value)
    {
        if (!ValidateCPF(value))
        {
            return Error.Validation("CPF.InvalidCPF", "O CPF é inválido.");
        }

        return new CPF(value.Trim().Replace(".", "").Replace("-", ""));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private static bool ValidateCPF(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
        {
            return false;
        }

        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        if (cpf.Length != 11)
        {
            return false;
        }

        if (cpf.Distinct().Count() == 1)
        {
            return false;
        }

        int[] multiplier1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
        int[] multiplier2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

        string tempCpf = cpf.Substring(0, 9);
        int sum = 0;

        for (int i = 0; i < 9; i++)
        {
            sum += int.Parse(tempCpf[i].ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture) * multiplier1[i];
        }

        int remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;

        string digit = remainder.ToString(CultureInfo.InvariantCulture);
        tempCpf += digit;
        sum = 0;

        for (int i = 0; i < 10; i++)
        {
            sum += int.Parse(tempCpf[i].ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture) * multiplier2[i];
        }

        remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;

        digit += remainder.ToString(CultureInfo.InvariantCulture);

        return cpf.EndsWith(digit, StringComparison.InvariantCulture);
    }
}
