using ErrorOr;
using MediatR;

namespace PokeChallenge.API.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<ErrorOr<TResponse>>
{
}
