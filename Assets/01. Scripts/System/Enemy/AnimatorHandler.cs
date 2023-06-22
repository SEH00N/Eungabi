using System;
using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    public event Action OnAnimationEndTrigger = null;
    public event Action OnAnimationEventTrigger = null;

    private Animator animator = null;

    private int speedHash = Animator.StringToHash("Speed");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnAnimationEnd() => OnAnimationEndTrigger?.Invoke();
    public void OnAnimationEvent() => OnAnimationEventTrigger?.Invoke();

    public void SetSpeed(float speed) => animator.SetFloat(speedHash, speed);
}
