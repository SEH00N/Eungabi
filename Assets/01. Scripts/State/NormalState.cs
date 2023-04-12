using UnityEngine;

public class NormalState : State
{
    public override void OnEnterState()
    {
        playerInput.OnMovementKeyPress += MovementHandle;
        playerInput.OnAttackKeyPress += AttackInputHandle;
        playerInput.OnRollingKeyPress += RollingInputHandle;
    }

    public override void UpdateState()
    {

    }

    public override void OnExitState()
    {

        playerInput.OnMovementKeyPress -= MovementHandle;
        playerInput.OnAttackKeyPress -= AttackInputHandle;
        playerInput.OnRollingKeyPress -= RollingInputHandle;
    }

    private void MovementHandle(Vector3 dir)
    {
        playerMovement.SetMovementDirection(dir);
    }

    private void AttackInputHandle(AttackFlag attackType)
    {
        stateHandler.ChangeState(attackType == AttackFlag.BaseAttack ? StateFlag.BaseAttack : StateFlag.SubAttack);
    }

    private void RollingInputHandle()
    {
        stateHandler.ChangeState(StateFlag.Rolling);
    }
}
