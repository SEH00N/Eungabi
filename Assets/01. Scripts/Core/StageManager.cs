using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private static StageManager instance = null;
    public static StageManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<StageManager>();

            return instance;
        }
    }

    [SerializeField] List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

    private void Awake()
    {
        Transform spawnPointTrm = GameObject.Find("SpawnPoints")?.transform;
        spawnPointTrm.GetComponentsInChildren<SpawnPoint>(spawnPoints);

        spawnPoints.Sort((a, b) => a.PointIndex - b.PointIndex);
    }
}
