using UnityEngine;

public class InteractState : State
{
    public override void OnEnterState()
    {
        playerMovement.IsActiveRotate = false;
        playerMovement.StopImmediatly();
        playerMovement.SetRotation(playerInput.GetMouseWorldPosition());

        CameraManager.Instance.ActiveCamera(CameraType.InteractCam);
        //플레이어 대가리 돌리기

    }

    public override void OnExitState()
    {
        playerMovement.IsActiveRotate = true;
    }

    public override void UpdateState()
    {
    }
}
