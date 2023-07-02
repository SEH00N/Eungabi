using UnityEngine;

public class PlayerData : StorableData
{
    public int SpawnPointIdx = -1;
    public int LuxCount = -1;
    public int CurrentStage = -1;

    public override bool IsNull()
    {
        if(SpawnPointIdx == -1 || LuxCount == -1 || CurrentStage == -1)
            return true;

        return false;
    }
}
