using System.Data;

namespace PokeChallenge.API.Application.Abstractions.Data;

public interface IDbConnectionFactory
{
    IDbConnection GetOpenConnection();
}
