namespace SW.PrimitiveTypes
{
    /// <summary>
    /// Implement this interface for an entity which must have TenantId.
    /// </summary>
    public interface IHasTenant
    {
        /// <summary>
        /// TenantId of this entity.
        /// </summary>
        int TenantId { get; set; }
    }
}