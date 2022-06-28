namespace ErpService.ModelData;

public abstract class ModelDataDb
{
    protected abstract List<ModelData> GetAllData();
    protected abstract bool SaveData(List<ModelData> modelDataList);

    public bool Add(string unicalName)
    {
        var modelDataList = GetAllData();
        ModelData modelData = new(NextIndex, unicalName);
        modelDataList.Add(modelData);
        return SaveData(modelDataList);
    }

    public bool Delete(int id)
    {
        var modelDataList = GetAllData();
        modelDataList.RemoveAt(id);
        return SaveData(modelDataList);
    }

    public ModelData? Get(int id)
    {
        var modelDataList = GetAllData();
        var modelData = GetAllData().FirstOrDefault(u => u.Id == id);
        if (modelData == null)
            return null;
        return modelData;
    }

    public int GetCount()
    {
        return GetAllData().Count;
    }

    public int? GetId(string unicalName)
    {
        var modelData = GetAllData().FirstOrDefault(u => u.UnicalName == unicalName);
        if (modelData == null)
            return null;
        return modelData.Id;
    }

    public bool IsActive(string unicalName)
    {
        var modelData = GetAllData().FirstOrDefault(u => u.UnicalName == unicalName);
        if (modelData == null)
            return false;
        return true;
    }

    protected int NextIndex
    {
        get
        {
            var modelDataList = GetAllData();
            return modelDataList.Any() ? modelDataList.Last().Id + 1 : 0;
        }
    }
}