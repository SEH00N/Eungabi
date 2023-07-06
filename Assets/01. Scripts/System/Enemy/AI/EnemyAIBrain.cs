using UnityEngine;

public class EnemyAIBrain : AIBrain
{
    private EnemyAIData aiData = null;
    public EnemyAIData AIData => aiData; 

    private EnemyHealth health = null;
    public EnemyHealth Health => health;

    private NavMovement navMovement = null;
    public NavMovement NavMovement => navMovement;

    protected override void Awake()
    {
        base.Awake();

        health = GetComponent<EnemyHealth>();
        navMovement = GetComponent<NavMovement>();
        aiData = new EnemyAIData();
    }

    private void Start()
    {
        aiData.Target = DEFINE.PlayerTrm;
    }
}
