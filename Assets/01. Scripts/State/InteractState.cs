using UnityEngine;

public class InteractState : State
{
    public override void OnEnterState()
    {
        

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
