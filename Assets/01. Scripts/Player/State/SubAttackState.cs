using UnityEngine;

public class SubAttackState : State
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

        playerAttack.ActiveSubWeapon();
        
        playerAnimator.OnAnimationEndTrigger += OnAnimationEndHandle;
    }

    public override void UpdateState()
    {
    }

    public override void OnExitState()
    {
        playerAnimator.ToggleAttack(false);

        playerMovement.IsActiveRotate = true;
        playerAnimator.OnAnimationEndTrigger -= OnAnimationEndHandle;
    }

    public void OnAnimationEndHandle()
    {
        playerAnimator.ToggleSubAttack(false);
        stateHandler.ChangeState(StateFlag.Normal);
    }
}
