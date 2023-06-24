using UnityEngine;

public abstract class EnemyAIAction : AIAction
{
    protected new EnemyAIBrain aiBrain = null;

    protected NavMovement navMovement = null;
    protected AnimatorHandler animator = null;

    public override void SetUp(Transform parentRoot)
    {
        navMovement = parentRoot.GetComponent<NavMovement>();
        animator = parentRoot.GetComponent<AnimatorHandler>();

        base.SetUp(parentRoot);
        aiBrain = base.aiBrain as EnemyAIBrain;
    }
}
