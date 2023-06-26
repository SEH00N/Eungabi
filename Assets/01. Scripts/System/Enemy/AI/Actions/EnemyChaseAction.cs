using UnityEngine;

public class EnemyChaseAction : EnemyAIAction
{
    [SerializeField] float retentionDistance;

    public override void TakeAction()
    {
        Vector3 direction = aiBrain.AIData.Target.position - transform.position;
        navMovement.MoveToTarget(aiBrain.AIData.Target.position - direction.normalized * retentionDistance);
    }
}
