using UnityEngine;

public class BaseAttackState : State
{
    private PlayerAttack playerAttack = null;

    public override void SetUp(Transform root)
    {
        base.SetUp(root);

        playerAttack = root.GetComponent<PlayerAttack>();
    }

    public override void OnEnterState()
    {
        playerMovement.IsActiveRotate = false;
        playerMovement.StopImmediatly();
        playerMovement.SetRotation(playerInput.GetMouseWorldPosition());

        playerAttack.ActiveMainWeapon();
        
        playerAnimator.OnAnimationEndTrigger += OnAnimationEndHandle;
    }

    public override void UpdateState()
    {
    }

    public override void OnExitState()
    {
        playerMovement.IsActiveRotate = true;
        playerAnimator.OnAnimationEndTrigger -= OnAnimationEndHandle;
    }

    public void OnAnimationEndHandle()
    {
        playerAnimator.ToggleAttack(false);
        stateHandler.ChangeState(StateFlag.Normal);
    }
}
