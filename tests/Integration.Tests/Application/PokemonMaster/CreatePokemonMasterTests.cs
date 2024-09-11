using System.Globalization;
using FluentAssertions;
using PokeChallenge.API.Application.PokemonMasters.Create;
using PokeChallenge.API.Domain.PokemonMasters;

namespace Integration.Tests.Application.PokemonMaster;

public class CreatePokemonMasterTests : BaseIntegrationTest
{
    public CreatePokemonMasterTests(IntegrationTestApiFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task Should_CreatePokemonMaster_WhenCommandIsValid()
    {
        // Arrange
        var request = new CreatePokemonMasterCommand(
            Faker.Name.FullName(),
            Faker.Internet.Email(),
            "298.474.060-22"
        );

        // Act
        var response = await Sender.Send(request);

        // Assert
        response.IsError.Should().BeFalse();
        response.Value.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task Should_NotCreatePokemonMaster_WhenEmailAlreadyExists()
    {
        // Arrange
        var email = Faker.Internet.Email();
        var request = new CreatePokemonMasterCommand(
            Faker.Name.FullName(),
            email,
            "298.474.060-22"
        );

        await Sender.Send(request);

        var request2 = new CreatePokemonMasterCommand(
            Faker.Name.FullName(),
            email,
            "298.474.060-22"
        );

        // Act
        var response = await Sender.Send(request2);

        // Assert
        response.IsError.Should().BeTrue();
        response.FirstError.Should().BeEquivalentTo(PokemonMasterErrors.EmailAlreadyExists());
    }
}
