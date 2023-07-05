using UnityEngine;

public class Altar : MonoBehaviour
{
    [SerializeField] int spawnPointIndex = 0;
    public int SpawnPointIndex => spawnPointIndex;

    [SerializeField] Transform spawnPosition;
    public Transform SpawnPosition => spawnPosition;

    public void SetSpawnPoint()
    {
        DataManager.Instance.PlayerData.SpawnPointIdx = spawnPointIndex;
    }
}
