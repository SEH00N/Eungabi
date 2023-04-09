using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public event Action OnAnimationEndTrigger = null;

    private Animator animator = null;

    private int speedHash = Animator.StringToHash("Speed");
    private int onSwingHash = Animator.StringToHash("OnSwing");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        OnAnimationEndTrigger += () => Debug.Log("Hello, World!");
    }

    public void OnAnimationEnd() => OnAnimationEndTrigger?.Invoke(); 

    public void SetSpeed(float speed) => animator.SetFloat(speedHash, speed);
    public void ToggleSwingTrigger(bool value)
    {
        if(value)
            animator.SetTrigger(onSwingHash);
        else
            animator.ResetTrigger(onSwingHash);
    }

}
