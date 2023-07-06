using UnityEngine;

public class Altar : MonoBehaviour
{
    [Header("SpawnPoint System")]
    [SerializeField] int spawnPointIndex = 0;
    public int SpawnPointIndex => spawnPointIndex;

    [SerializeField] Transform spawnPosition;
    public Transform SpawnPosition => spawnPosition;


    [Header("Boss System")]
    [SerializeField] int requiredLuxQuantity = 10;
    [SerializeField] EnemyAIBrain guardianPrefab = null;

    private PlayerStatus playerStatus = null;

    private void Awake()
    {
        if(spawnPosition == null)
            spawnPosition = transform;

        playerStatus = DEFINE.PlayerTrm.GetComponent<PlayerStatus>();
    }

    public void SetSpawnPoint()
    {
        DataManager.Instance.PlayerData.SpawnPointIdx = spawnPointIndex;
    }

    public void SpawnGuardian()
    {
        if(playerStatus.LightQuantity < requiredLuxQuantity)
        {
            Debug.Log("부족해 이년아");
            return;
        }

        EnemyAIBrain guardian = PoolManager.Instance.Pop(guardianPrefab) as EnemyAIBrain;
        guardian.transform.position = spawnPosition.position;
        guardian.NavMovement.NavAgent.enabled = true;

        playerStatus.LightQuantity -= requiredLuxQuantity;
    }
}
