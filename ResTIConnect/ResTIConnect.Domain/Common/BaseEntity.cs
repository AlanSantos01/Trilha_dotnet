namespace ResTIConnect.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DateUpdate { get; set; }
    public DateTimeOffset? DateDeleted { get; set; }
}

