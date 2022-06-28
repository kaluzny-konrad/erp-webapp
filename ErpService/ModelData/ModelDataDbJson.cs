using System.Text.Json;

namespace ErpService.ModelData;

public class ModelDataDbJson : ModelDataDb, IModelDataDb
{
    private ModelDataDbJson() { }
    private static ModelDataDbJson? _instance;

    public static IModelDataDb GetDb()
    {
        if (_instance == null)
            _instance = new ModelDataDbJson();
        return _instance;
    }

    protected override List<ModelData> GetAllData()
    {
        List<ModelData>? modelDataList;
        var data = DbJsonSaver.GetData(fileName);
        try
        {
            modelDataList = JsonSerializer.Deserialize(data,
                typeof(List<ModelData>)) as List<ModelData>;
        }
        catch (JsonException)
        {
            modelDataList = new List<ModelData>();
        }
        if (modelDataList == null)
            modelDataList = new List<ModelData>();
        return modelDataList;
    }

    protected override bool SaveData(List<ModelData> modelDataList)
    {
        string json = JsonSerializer.Serialize(modelDataList);
        DbJsonSaver.SaveData(json, fileName);
        return true;
    }

    private static string fileName = "JsonModelData.txt";
}