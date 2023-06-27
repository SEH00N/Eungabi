using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : PoolableMono
{
    private Stack<T> pool = new Stack<T>();
    private T prefab;
    private Transform parent;

    public Pool(T prefab, Transform parent)
    {
        this.prefab = prefab;
        this.parent = parent;
    }

    public T Pop()
    {
        T obj= null;

        if(pool.Count > 0)
        {
            obj = pool.Pop();
            obj.gameObject.SetActive(true);
        }
        else
        {
            obj = GameObject.Instantiate(prefab, parent);
            obj.gameObject.name = obj.name.Replace("(Clone)", "");
        }

        return obj;
    }

    public void Push(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Push(obj);
    }
}
