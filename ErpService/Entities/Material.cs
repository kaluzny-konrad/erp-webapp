namespace ErpService.Entities;

public class Material : BaseEntity
{
    public Material(int id, string unicalName, int warehouseId) : base(id, unicalName)
    {
        WarehouseId = warehouseId;
    }

    public int WarehouseId { get; }
}
