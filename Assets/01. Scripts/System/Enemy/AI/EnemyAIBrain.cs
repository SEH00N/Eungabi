using UnityEngine;

public class EnemyAIBrain : AIBrain
{
    private EnemyAIData aiData = null;
    public EnemyAIData AIData => aiData; 

    private EnemyHealth health = null;
    public EnemyHealth Health => health;

    protected override void Awake()
    {
        base.Awake();

        health = GetComponent<EnemyHealth>();
        aiData = new EnemyAIData();
    }
}
