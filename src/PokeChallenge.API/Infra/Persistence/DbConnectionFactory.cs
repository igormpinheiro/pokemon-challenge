using System.Data;
using Microsoft.Data.Sqlite;
using PokeChallenge.API.Application.Abstractions.Data;

namespace PokeChallenge.API.Infra.Persistence;

public class DbConnectionFactory(string connectionString) : IDbConnectionFactory
{
    private readonly string _connectionString = connectionString;

    public IDbConnection GetOpenConnection()
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();

        return connection;
    }
}
