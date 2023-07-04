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

    [SerializeField] List<Altar> altars = new List<Altar>();

    private void Awake()
    {
        Transform altarTrm = GameObject.Find("Altars")?.transform;
        altarTrm.GetComponentsInChildren<Altar>(altars);

        altars.Sort((a, b) => a.SpawnPointIndex - b.SpawnPointIndex);
    }
}
