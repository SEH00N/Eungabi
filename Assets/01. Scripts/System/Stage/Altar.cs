using UnityEngine;

public class Altar : MonoBehaviour
{
    [SerializeField] int spawnPointIndex = 0;
    public int SpawnPointIndex => spawnPointIndex;

    public void SetSpawnPoint()
    {
        DataManager.Instance.PlayerData.SpawnPointIdx = spawnPointIndex;
    }
}
