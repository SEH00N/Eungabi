using UnityEngine;

public abstract class EnemyAIState : AIState
{
    public EnemyAIBrain AIBrain => base.aiBrain as EnemyAIBrain;

    protected NavMovement movement = null;
    protected AnimatorHandler animator = null;

    public override void SetUp(Transform parentRoot)
    {
        movement = parentRoot.GetComponent<NavMovement>();
        animator = parentRoot.Find("Model").GetComponent<AnimatorHandler>();

        base.SetUp(parentRoot);
    }
}
