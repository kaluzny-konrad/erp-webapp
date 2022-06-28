namespace ErpService.ModelData;

public interface IModelDataDb
{
    bool Add(string unicalName);
    int? GetId(string unicalName);
    public bool Delete(int id);
    public ModelData? Get(int id);
    bool IsActive(string unicalName);
    int GetCount();
}