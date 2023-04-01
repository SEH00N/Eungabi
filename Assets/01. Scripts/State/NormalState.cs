using System;
using UnityEngine;

public class NormalState : State
{
    public override void OnEnterState()
    {
        playerInput.OnMovementKeyPress += MovementHandle;
        playerInput.OnAttackKeyPress += AttackInputHandle;
    }

    public override void OnExitState()
    {

    }

    public override void UpdateState()
    {

    }

    private void MovementHandle(Vector3 dir)
    {
        playerMovement.SetMovementVelocity(dir);
    }

    private void AttackInputHandle(AttackType attackType)
    {
        stateController.ChangeState(attackType == AttackType.MainAttack ? StateType.MainAttack : StateType.SubAttack);
    }
}
