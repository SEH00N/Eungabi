using System.Collections.Generic;
using Newtonsoft.Json;

[System.Serializable]
public class StageData : StorableData
{
    [JsonProperty("StageCount")] public int StageCount;
    [JsonProperty("StageInfo")] public List<List<bool>> StageInfo;

    public StageData()
    {
        StageInfo = new List<List<bool>>();
        
        for(int i = 0; i < StageCount; i++)
            StageInfo.Add(new List<bool>());
    }

    public override bool IsNull()
    {
        if(StageInfo == null)
            return false;

        foreach(List<bool> lights in StageInfo)
            if(lights == null)
                return false;

        return true;
    }
}
