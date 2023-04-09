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
        playerMovement.StopImmediatly();
        playerAttack.ActiveMainWeapon();
        
        playerAnimator.OnAnimationEndTrigger += OnAnimationEndHandle;
    }

    public override void OnExitState()
    {
        playerAnimator.OnAnimationEndTrigger -= OnAnimationEndHandle;
    }

    public override void UpdateState()
    {
    }

    public void OnAnimationEndHandle()
    {
        stateHandler.ChangeState(StateFlag.Normal);
    }
}
