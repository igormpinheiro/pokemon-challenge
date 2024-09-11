using ErrorOr;
using FluentAssertions;
using NSubstitute;
using PokeChallenge.API.Application.PokemonMasters.Create;
using PokeChallenge.API.Domain.PokemonMasters;

namespace Unit.Tests.Application;

public class CreatePokemonMasterCommandTests
{
    private static readonly CreatePokemonMasterCommand Command = new("Fulano Silva", "fulano.silva@test.com", "298.474.060-22");

    private readonly CreatePokemonMasterCommandHandler _handler;
    private readonly IPokemonMasterRepository _repositoryMock;

    public CreatePokemonMasterCommandTests()
    {
        _repositoryMock = Substitute.For<IPokemonMasterRepository>();
        _handler = new CreatePokemonMasterCommandHandler(_repositoryMock);
    }

    [Fact]
    public async Task Handle_Should_ReturnError_WhenEmailIsInvalid()
    {
        // Arrange
        var invalidCommand = Command with { Email = "invalid_email" };

        // Act
        var result = await _handler.Handle(invalidCommand, default);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Code.Should().Be("Email.InvalidEmail");
    }

    [Fact]
    public async Task Handle_Should_ReturnError_WhenEmailIsNotUnique()
    {
        // Arrange
        _repositoryMock
            .IsEmailUniqueAsync(Arg.Is<Email>(e => e.Value == Command.Email), CancellationToken.None)
            .Returns(false);

        // Act
        var result = await _handler.Handle(Command, default);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.Conflict);
        result.FirstError.Code.Should().Be(PokemonMasterErrors.EmailAlreadyExists().Code);
    }

    [Fact]
    public async Task Handle_Should_ReturnError_WhenCpfIsInvalid()
    {
        // Arrange
        var invalidCommand = Command with { CPF = "invalid_cpf" };

        _repositoryMock
            .IsEmailUniqueAsync(Arg.Is<Email>(e => e.Value == Command.Email), CancellationToken.None)
            .Returns(true);

        // Act
        var result = await _handler.Handle(invalidCommand, default);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Code.Should().Be("CPF.InvalidCPF");
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccess_WhenCreateSucceeds()
    {
        // Arrange
        _repositoryMock
            .IsEmailUniqueAsync(Arg.Is<Email>(e => e.Value == Command.Email), CancellationToken.None)
            .Returns(true);

        // Act
        var result = await _handler.Handle(Command, default);

        // Assert
        result.IsError.Should().BeFalse();
    }

    [Fact]
    public async Task Handle_Should_CallRepository_WhenCreateSucceeds()
    {
        // Arrange
        _repositoryMock
            .IsEmailUniqueAsync(Arg.Is<Email>(e => e.Value == Command.Email), CancellationToken.None)
            .Returns(true);

        // Act
        var result = await _handler.Handle(Command, default);

        // Assert
        _repositoryMock.Received(1).Insert(Arg.Is<PokemonMaster>(u => u.Id == result.Value));
    }

}
