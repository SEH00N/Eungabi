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
    public List<Altar> Altars => altars;

    private void Awake()
    {
        Transform altarTrm = GameObject.Find("Altars")?.transform;
        Debug.Log(altarTrm.childCount);
        altarTrm.GetComponentsInChildren<Altar>(true, altars);

        altars.Sort((a, b) => a.SpawnPointIndex - b.SpawnPointIndex);
    }
}
