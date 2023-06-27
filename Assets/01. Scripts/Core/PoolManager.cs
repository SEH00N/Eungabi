using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private static PoolManager instance = null;
    public static PoolManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<PoolManager>();

            return instance;
        }
    }

    [SerializeField] List<PoolableMono> poolingList = new List<PoolableMono>();
    private Dictionary<string, Pool<PoolableMono>> pools = new Dictionary<string, Pool<PoolableMono>>();

    public void CreatePool(PoolableMono prefab)
    {
        if(pools.ContainsKey(prefab.name)) 
        { 
            Debug.LogWarning($"current name of pool already existed on pools : {prefab.name}"); 
            return;
        }

        Pool<PoolableMono> pool = new Pool<PoolableMono>(prefab, transform);
        pools.Add(prefab.gameObject.name, pool);
    }

    public void Push(PoolableMono obj)
    {
        if(pools.ContainsKey(obj.name) == false) 
        { 
            Debug.LogWarning($"current name of pool doesn't existed on pools : {obj.name}"); 
            return;
        }

        pools[obj.name].Push(obj);
    }

    public PoolableMono Pop(string prefabName)
    {
        if(pools.ContainsKey(prefabName) == false) 
        { 
            Debug.LogWarning($"current name of pool doesn't existed on pools : {prefabName}, returning null"); 
            return null;
        }

        PoolableMono obj = pools[prefabName].Pop();
        obj.Init();

        return obj;
    }

    public PoolableMono Pop(PoolableMono prefab) => Pop(prefab.name);
}
