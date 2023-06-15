using System;
using System.Collections;
using UnityEngine;

public class RollingState : State
{
    [SerializeField] float postponeTime = 0.07f;
    [SerializeField] float rollingSpeed = 10f;

    private Vector3 direction;

    public override void OnEnterState()
    {   
        playerAnimator.OnAnimationEndTrigger += OnAnimationEndHandle;

        playerMovement.IsActiveMove = false;
        playerMovement.StopImmediatly();

        direction = Quaternion.Euler(0, -45f, 0) * playerInput.GetCurrentInputDirection().normalized;
        if (direction.sqrMagnitude <= 0)
            direction = stateHandler.transform.forward;

        StartCoroutine(DelayCoroutine(postponeTime, () => {
            playerMovement.SetRotationImmediatly(direction + stateHandler.transform.position);
            playerMovement.SetMovementVelocity(direction * rollingSpeed);

            playerAnimator.ToggleRolling(true);
        }));
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
        playerMovement.StopImmediatly();

        StartCoroutine(DelayCoroutine(postponeTime, () => {
            playerAnimator.ToggleRolling(false);

            stateHandler.ChangeState(StateFlag.Normal);
        }));
    }

    private IEnumerator DelayCoroutine(float delay, Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }
}
