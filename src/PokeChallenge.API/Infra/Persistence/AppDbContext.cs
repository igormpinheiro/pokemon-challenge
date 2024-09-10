using Microsoft.EntityFrameworkCore;

namespace PokeChallenge.API.Infra.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
