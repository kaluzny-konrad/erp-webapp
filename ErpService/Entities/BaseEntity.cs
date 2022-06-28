namespace ErpService.Entities;

public abstract class BaseEntity
{
    public BaseEntity(int id, string unicalName)
    {
        Id = id;
        UnicalName = unicalName;
    }

    public int Id { get; }
    public string UnicalName { get; }
}
