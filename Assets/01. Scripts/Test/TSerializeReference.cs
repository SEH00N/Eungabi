using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Base
{
    public int a;
}

[Serializable]
public class Child1 : Base
{
    public int b;
}

[Serializable]
public class Child2 : Base
{
    public int b;
    public int c;
}

public class TSerializeReference : MonoBehaviour
{
    [SerializeReference] Base a = new Child1();
    [SerializeReference] Base b = new Child2();
    [SerializeReference] List<Base> bList = new List<Base>();

    private void Awake()
    {
        bList.Add(new Base());
        bList.Add(new Child1());
        bList.Add(new Child2());
    }
}
