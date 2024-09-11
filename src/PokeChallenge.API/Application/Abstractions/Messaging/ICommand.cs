using ErrorOr;
using MediatR;

namespace PokeChallenge.API.Application.Abstractions.Messaging;

public interface ICommand : IRequest<IErrorOr>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<ErrorOr<TResponse>>, IBaseCommand;

public interface IBaseCommand;
