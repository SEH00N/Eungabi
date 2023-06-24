public class EnemyChaseAction : EnemyAIAction
{
    public override void TakeAction()
    {
        navMovement.MoveToTarget(aiBrain.AIData.Target.position);
    }
}
