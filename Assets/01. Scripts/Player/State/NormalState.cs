using UnityEngine;

public class NormalState : State
{
    private DialogController dialogController = null;

    public override void SetUp(Transform root)
    {
        base.SetUp(root);
        dialogController = root.GetComponent<DialogController>();
    }

    public override void OnEnterState()
    {
        playerInput.OnMovementKeyPress += MovementHandle;
        playerInput.OnAttackKeyPress += AttackInputHandle;
        playerInput.OnRollingKeyPress += RollingInputHandle;
        playerInput.OnInteractKeyPress += InteractInputHandle;
    }

    public override void UpdateState()
    {

    }

    public override void OnExitState()
    {
        playerInput.OnMovementKeyPress -= MovementHandle;
        playerInput.OnAttackKeyPress -= AttackInputHandle;
        playerInput.OnRollingKeyPress -= RollingInputHandle;
        playerInput.OnInteractKeyPress -= InteractInputHandle;
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

    private void InteractInputHandle()
    {
        dialogController.ActiveDialog();
    }
}
