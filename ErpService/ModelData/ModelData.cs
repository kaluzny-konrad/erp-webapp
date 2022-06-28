namespace ErpService.ModelData;

public class ModelData
{
    public ModelData(int id, string unicalName)
    {
        Id = id;
        UnicalName = unicalName;
    }

    public int Id { get; }
    public string UnicalName { get; }
}
