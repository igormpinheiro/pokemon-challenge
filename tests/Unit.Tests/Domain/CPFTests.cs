using ErrorOr;
using FluentAssertions;
using PokeChallenge.API.Domain.PokemonMasters;

namespace Unit.Tests.Domain;

public class CPFTests
{
    [Theory]
    [InlineData("298.474.060-22")]
    [InlineData("29847406022")]
    [InlineData("665.438.920-48")]
    public void Create_WithValidCPF_ShouldReturnValidCPF(string validCPF)
    {
        // Act
        var result = CPF.Create(validCPF);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Value.Should().Be(validCPF.Replace(".", "").Replace("-", ""));
        result.Value.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("123")]
    [InlineData("invalid_cpf")]
    [InlineData("123.456.789-00")]
    [InlineData("111.111.111-11")]
    [InlineData("999.999.999-99")]
    [InlineData("123.456.789-10")]
    public void Create_WithInvalidCPF_ShouldReturnError(string invalidCPF)
    {
        // Act
        var result = CPF.Create(invalidCPF);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.Validation);
        result.FirstError.Code.Should().Be("CPF.InvalidCPF");
        result.FirstError.Description.Should().Be("O CPF é inválido.");
    }
}
