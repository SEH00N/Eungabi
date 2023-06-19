using System.Collections.Generic;
using Newtonsoft.Json;

[System.Serializable]
public class StageData : StorableData
{
    [JsonProperty("StageCount")] public int StageCount;
    [JsonProperty("StageInfo")] public List<List<bool>> StageInfo;
    [JsonProperty("StageClearData")] public List<bool> StageClearInfo;

    public StageData()
    {
        StageClearInfo = new List<bool>();
        StageInfo = new List<List<bool>>();
        
        for(int i = 0; i < StageCount; i++)
            StageInfo.Add(new List<bool>());
    }

    public override bool IsNull()
    {
        if(StageClearInfo == null)
            return false;

        if(StageInfo == null)
            return false;

        foreach(List<bool> lights in StageInfo)
            if(lights == null)
                return false;

        return true;
    }
}
