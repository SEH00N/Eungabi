using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public static DataManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<DataManager>();

            return instance;
        }
    }

    private string savePath = "us4dnt";

    public StageData StageData;
    public PlayerData PlayerData;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, savePath);
        Debug.Log(savePath);
    
        if(instance != null)
            return;

        if(!Directory.Exists(savePath))
            Directory.CreateDirectory(savePath);

        StageData = TryReadJson<StageData>();
        PlayerData = TryReadJson<PlayerData>();
    }

    private void OnDestroy()
    {
        if(instance != this)
            return;

        SaveData<StageData>(StageData);
        SaveData<PlayerData>(PlayerData);
    }

    private void OnApplicationQuit()
    {
        SaveData<StageData>(StageData);
    }

    private T TryReadJson<T>() where T : StorableData, new()
    {
        T data;
        string json = File.ReadAllText(GetPath<T>());

        if(json.Length > 0)
        {
            data = JsonConvert.DeserializeObject<T>(json);

            if(data.IsNull())
                data = new T();
        }
        else
            data = new T();

        return data;
    }

    private void SaveData<T>(T data) where T : StorableData
    {
        string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(GetPath<T>(), json);
    }

    private string GetPath<T>()
    {
        string path = $"{savePath}/{typeof(T)}.json";
        
        if(!File.Exists(path))
            File.Create(path).Close();

        return path;
    }
}
