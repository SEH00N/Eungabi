using UnityEngine;

public abstract class EnemyAIAction : AIAction
{
    protected EnemyAIBrain aiBrain = null;

    protected NavMovement navMovement = null;
    protected AnimatorHandler animator = null;

    public override void SetUp(Transform parentRoot)
    {
        navMovement = parentRoot.GetComponent<NavMovement>();
        animator = parentRoot.Find("Model").GetComponent<AnimatorHandler>();

        aiBrain = parentRoot.GetComponent<EnemyAIBrain>();

        base.SetUp(parentRoot);
    }
}
