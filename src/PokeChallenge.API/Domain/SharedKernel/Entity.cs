namespace PokeChallenge.API.Domain.SharedKernel;

public abstract class Entity
{
    public int Id { get; init; }

    protected Entity(int id)
    {
        Id = id;
    }

    protected Entity()
    {
    }
}
