using UnityEngine;

public abstract class EnemyAIDecision : AIDecision
{
    protected EnemyAIBrain aiBrain = null;

    public override void SetUp(Transform parentRoot)
    {
        base.SetUp(parentRoot);

        aiBrain = parentRoot.GetComponent<EnemyAIBrain>();
    }
}
