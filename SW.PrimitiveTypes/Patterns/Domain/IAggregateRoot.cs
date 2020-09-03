namespace SW.PrimitiveTypes
{
    public interface IAggregateRoot : IAggregateRoot<int>, IEntity
    {
    }

    public interface IAggregateRoot<TPrimaryKey> : IEntity<TPrimaryKey>, IGeneratesDomainEvents
    {
    }
}
