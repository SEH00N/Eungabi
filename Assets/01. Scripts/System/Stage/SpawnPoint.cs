using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] int pointIndex = 0;
    public int PointIndex => pointIndex;

    public void SetSpawnPoint()
    {
        DataManager.Instance.PlayerData.SpawnPointIdx = pointIndex;
    }
}
