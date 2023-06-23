using UnityEngine;

public class EnemyAIBrain : AIBrain
{
    private Transform target = null;
    public Transform Target => target;

    private EnemyHealth health = null;
    public EnemyHealth Health => health;

    protected override void Awake()
    {
        base.Awake();

        health = GetComponent<EnemyHealth>();
    }
}
