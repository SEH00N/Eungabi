using System;
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
        playerAnimator.OnAnimationEventTrigger += OnAnimationEventHandle;
    }

    public override void UpdateState()
    {
    }

    public override void OnExitState()
    {
        playerAnimator.ToggleAttack(false);

        playerMovement.IsActiveRotate = true;
        playerAnimator.OnAnimationEndTrigger -= OnAnimationEndHandle;
        playerAnimator.OnAnimationEventTrigger -= OnAnimationEventHandle;
    }

    private void OnAnimationEventHandle()
    {
        //Debug.Log("asd");
        //playerAttack.ActiveMainWeapon();
    }
    //여기 해야댐
    public void OnAnimationEndHandle()
    {
        playerAnimator.ToggleAttack(false);
        stateHandler.ChangeState(StateFlag.Normal);
    }
}
