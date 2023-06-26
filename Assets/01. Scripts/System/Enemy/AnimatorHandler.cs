using System;
using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    public event Action OnAnimationEndTrigger = null;
    public event Action OnAnimationEventTrigger = null;

    private Animator animator = null;

    private int speedHash = Animator.StringToHash("Speed");
    private int onGroggyHash = Animator.StringToHash("OnGroggy");
    private int onAttack1Hash = Animator.StringToHash("OnAttack1");
    private int onAttack2Hash = Animator.StringToHash("OnAttack2");
    private int onAttack3Hash = Animator.StringToHash("OnAttack3");
    private int isHitHash = Animator.StringToHash("IsHit");
    private int isDeadHash = Animator.StringToHash("IsDead");
    private int hitTriggerHash = Animator.StringToHash("Hit");
    private int deadTriggerHash = Animator.StringToHash("Dead");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnAnimationEnd() => OnAnimationEndTrigger?.Invoke();
    public void OnAnimationEvent() => OnAnimationEventTrigger?.Invoke();

    public void SetSpeed(float speed) => animator.SetFloat(speedHash, speed);
    public void ToggleGroggy(bool value) => animator.SetBool(onGroggyHash, value);
    public void ToggleAttack1(bool value) => animator.SetBool(onAttack1Hash, value);
    public void ToggleAttack2(bool value) => animator.SetBool(onAttack2Hash, value);
    public void ToggleAttack3(bool value) => animator.SetBool(onAttack3Hash, value);
    public void ToggleHit(bool value) => SetTrigger(isHitHash, value);
    public void ToggleDead(bool value) => animator.SetBool(isDeadHash, value);
    public void SetHitTrigger(bool value) => SetTrigger(hitTriggerHash, value);
    public void SetDeadTrigger(bool value) => SetTrigger(deadTriggerHash, value);

    private void SetTrigger(int hash, bool value)
    {
        if(value)
            animator.SetTrigger(hash);
        else 
            animator.ResetTrigger(hash);
    }
}
