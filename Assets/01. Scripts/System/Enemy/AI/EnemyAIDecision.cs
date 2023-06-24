using UnityEngine;

public abstract class EnemyAIDecision : AIDecision
{
    protected new EnemyAIBrain aiBrain = null;

    public override void SetUp(Transform parentRoot)
    {
        base.SetUp(parentRoot);

        aiBrain = base.aiBrain as EnemyAIBrain;
    }
}
