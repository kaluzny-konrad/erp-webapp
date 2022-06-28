namespace ErpService.ModelData;

public class ModelDataDbTest : ModelDataDb, IModelDataDb
{
    private ModelDataDbTest()
    {
        _modelDataList = new List<ModelData>();
    }

    public static IModelDataDb GetDb() => new ModelDataDbTest();

    protected override List<ModelData> GetAllData() => _modelDataList;

    protected override bool SaveData(List<ModelData> modelDataList)
    {
        _modelDataList = modelDataList;
        return true;
    }

    private List<ModelData> _modelDataList;
}