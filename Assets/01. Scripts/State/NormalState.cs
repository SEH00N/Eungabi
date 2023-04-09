using UnityEngine;

public class NormalState : State
{
    public override void OnEnterState()
    {
        playerInput.OnMovementKeyPress += MovementHandle;
        playerInput.OnAttackKeyPress += AttackInputHandle;
    }

    public override void UpdateState()
    {

    }

    public override void OnExitState()
    {

        playerInput.OnMovementKeyPress -= MovementHandle;
        playerInput.OnAttackKeyPress -= AttackInputHandle;
    }

    private void MovementHandle(Vector3 dir)
    {
        playerMovement.SetMovementVelocity(dir);
    }

    private void AttackInputHandle(AttackFlag attackType)
    {
        stateHandler.ChangeState(attackType == AttackFlag.BaseAttack ? StateFlag.BaseAttack : StateFlag.SubAttack);
    }
}
