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
    public int c;
    public int d;
}

public class TSerializeReference : MonoBehaviour
{
    [SerializeReference] Base foo = new Child1();
    [SerializeReference] Base bar = new Child2();
    [SerializeReference] List<Base> foobar = new List<Base>() {
        new Base(),
        new Child1(),
        new Child2()
    };
}
