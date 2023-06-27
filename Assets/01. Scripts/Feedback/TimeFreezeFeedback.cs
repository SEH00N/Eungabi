using UnityEngine;

public class TimeFreezeFeedback : Feedback
{
    [SerializeField] float freezeDelay = 0.05f;
    [SerializeField] float freezeDuration = 0.02f;

    [SerializeField, Range(0, 1f)] float timeFreezeValue = 0.02f;

    public override void CreateFeedback()
    {
        TimeController.Instance.ModifyTimeScale(timeFreezeValue, freezeDelay, () => {
            TimeController.Instance.ModifyTimeScale(1, freezeDuration);
        });
    }

    public override void FinishFeedback()
    {
        if(TimeController.Instance != null)
            TimeController.Instance.ResetTimeScale();
    }
}
