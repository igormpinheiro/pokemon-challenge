using ErrorOr;
using MediatR;

namespace PokeChallenge.API.Application.Abstractions.Messaging;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, IErrorOr>
    where TCommand : ICommand
{
}

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, ErrorOr<TResponse>>
    where TCommand : ICommand<TResponse>
{
}
