using Bogus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PokeChallenge.API.Infra.Persistence;

namespace Integration.Tests;

public class BaseIntegrationTest : IClassFixture<IntegrationTestApiFactory>, IDisposable
{
    private readonly IServiceScope _scope;
    protected ISender Sender { get; }
    protected AppDbContext DbContext { get; }
    protected Faker Faker { get; }

    protected BaseIntegrationTest(IntegrationTestApiFactory factory)
    {
        _scope = factory.Services.CreateScope();
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = _scope.ServiceProvider.GetRequiredService<AppDbContext>();
        Faker = new Faker();
    }

    public void Dispose()
    {
        _scope.Dispose();
    }
}
