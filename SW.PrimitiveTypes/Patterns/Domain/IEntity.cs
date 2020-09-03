namespace SW.PrimitiveTypes
{
    public interface IEntity : IEntity<int>
    {
    }

    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        TPrimaryKey Id { get; set; }
    }
}
