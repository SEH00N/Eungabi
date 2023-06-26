using UnityEngine;

public class OnAttackDecision : EnemyAIDecision
{
    public override bool MakeDecision()
    {
        return aiBrain.AIData.OnAttack;
    }
}
