namespace ErpService.ModelData;

public class ModelDataManager
{
    private ModelDataManager(IModelDataDb modelDataDb)
    {
        _modelDataDb = modelDataDb;
    }

    private static ModelDataManager? _instance;

    public static ModelDataManager GetManager(IModelDataDb modelDataDb)
    {
        if (_instance == null)
            _instance = new ModelDataManager(modelDataDb);
        return _instance;
    }

    public int Count => _modelDataDb.GetCount();

    public bool New(string unicalName)
    {
        if (!_modelDataDb.IsActive(unicalName))
            return _modelDataDb.Add(unicalName);
        return false;
    }

    public ModelData? Get(string unicalName)
    {
        var id = _modelDataDb.GetId(unicalName);
        if (id == null)
            return null;
        else
            return _modelDataDb.Get((int)id);
    }

    public void Delete(int id) => _modelDataDb.Delete(id);

    public static void DeleteInstance() => _instance = null;

    private readonly IModelDataDb _modelDataDb;
}