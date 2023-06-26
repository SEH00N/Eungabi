using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimationHandleAction : EnemyAIAction
{
    [SerializeField] UnityEvent OnAnimationEventHandle;
    [SerializeField] UnityEvent OnAnimationEndHandle;

    public override void TakeAction()
    {
        
    }

    public void SubscribeHandle()
    {
        animator.OnAnimationEndTrigger += AnimationEndHandle;
        animator.OnAnimationEventTrigger += AnimationEventHandle;
    }

    public void RemoveHandle()
    {
        animator.OnAnimationEndTrigger -= AnimationEndHandle;
        animator.OnAnimationEventTrigger -= AnimationEventHandle;
    }

    private void AnimationEndHandle()
    {
        OnAnimationEndHandle?.Invoke();
    }

    private void AnimationEventHandle()
    {
        OnAnimationEventHandle?.Invoke();
    }
}
