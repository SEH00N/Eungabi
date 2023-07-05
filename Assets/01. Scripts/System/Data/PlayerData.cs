public class PlayerData : StorableData
{
    public int SpawnPointIdx = -1;
    public int LuxCount = -1;
    public int CurrentStage = -1;

    public PlayerData()
    {
        SpawnPointIdx = 0;
        LuxCount = 0;
        CurrentStage = 0;
    }

    public override bool IsNull()
    {
        if(SpawnPointIdx == -1 || LuxCount == -1 || CurrentStage == -1)
            return true;

        return false;
    }
}
