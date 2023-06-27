using UnityEngine;

public class CamShakeFeedback : Feedback
{
    [SerializeField, Tooltip("진동수")] float frequency = 3f;
    [SerializeField, Tooltip("진폭")] float amplitude = 3.4f;
    [SerializeField] float duration = 0.09f;

    public override void CreateFeedback()
    {
        CameraManager.Instance.ShakeCam(duration, amplitude, frequency);
    }

    public override void FinishFeedback()
    {
        if(CameraManager.Instance != null)
            CameraManager.Instance.ResetShake();
    }

    protected override void OnDisable()
    {
        
    }
}
