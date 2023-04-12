using UnityEngine;

public class RollingState : State
{
    [SerializeField] float rollingSpeed = 10f;

    public override void OnEnterState()
    {
        playerAnimator.OnAnimationEndTrigger += OnAnimationEndHandle;

        playerMovement.StopImmediatly();
        playerMovement.IsActiveMove = false;

        Vector3 direction = Quaternion.Euler(0, -45f, 0) * playerInput.GetCurrentInputDirection();
        if(direction.sqrMagnitude <= 0)
            direction = stateHandler.transform.forward;

        playerMovement.SetRotation(direction + stateHandler.transform.position);
        playerMovement.SetMovementVelocity(direction * rollingSpeed);

        playerAnimator.ToggleRolling(true);
    }

    public override void OnExitState()
    {
        playerMovement.StopImmediatly();
        playerMovement.IsActiveMove = true;

        playerAnimator.OnAnimationEndTrigger -= OnAnimationEndHandle;
    }

    public override void UpdateState()
    {
    }

    private void OnAnimationEndHandle()
    {
        playerAnimator.ToggleRolling(false);
        stateHandler.ChangeState(StateFlag.Normal);
    }
}
