using System.Net;
using System.Net.Http.Json;
using PokeChallenge.API.Controllers.v1.PokemonMasters;

namespace FunctionalTests.PokemonMasters;

public class RegisterPokemonMasterTests : BaseFunctionalTest
{
    public RegisterPokemonMasterTests(FunctionalTestWebAppFactory factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task Register_ShouldReturnBadRequest_WhenRequestIsInvalid()
    {
        // Arrange
        var request = new RegisterPokemonMasterRequest("Fulano Silva", "invalid_email", "00000000191");

        // Act
        var response = await HttpClient.PostAsJsonAsync("api/v1/pokemon-masters", request);

        // Assert
        Assert.False(response.IsSuccessStatusCode);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Register_ShouldReturnOk_WhenRequestIsValid()
    {
        // Arrange
        var request = new RegisterPokemonMasterRequest("Fulano Silva", "fulano.silva@test.com", "00000000191");

        // Act
        var response = await HttpClient.PostAsJsonAsync("api/v1/pokemon-masters", request);

        // Assert
        Assert.True(response.IsSuccessStatusCode);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}
