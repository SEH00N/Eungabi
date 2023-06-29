using UnityEngine;

public class HitState : State
{
    public override void OnEnterState()
    {
        playerMovement.StopImmediatly();

        playerAnimator.SetHitTrigger(true);

        playerAnimator.OnAnimationEventTrigger += OnAnimationEventHandle;
        playerAnimator.OnAnimationEndTrigger += OnAnimationEndHandle;
    }

    public override void OnExitState()
    {
        playerAnimator.ToggleHit(false);

        playerAnimator.OnAnimationEventTrigger -= OnAnimationEventHandle;
        playerAnimator.OnAnimationEndTrigger -= OnAnimationEndHandle;
    }

    public override void UpdateState()
    {

    }

    private void OnAnimationEndHandle()
    {
        stateHandler.ChangeState(StateFlag.Normal);
    }

    private void OnAnimationEventHandle()
    {
        playerAnimator.ToggleHit(true);
    }
}
