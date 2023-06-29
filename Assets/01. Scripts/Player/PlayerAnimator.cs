using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public event Action OnAnimationEndTrigger = null;
    public event Action OnAnimationEventTrigger = null;

    private Animator animator = null;

    private int speedHash = Animator.StringToHash("Speed");
    private int onAttackHash = Animator.StringToHash("OnAttack");
    private int onSubAttackHash = Animator.StringToHash("OnSubAttack");
    private int onRollingHash = Animator.StringToHash("OnRolling");
    private int isDeadHash = Animator.StringToHash("IsDead");
    private int isHitHash = Animator.StringToHash("IsHit");
    private int deadHash = Animator.StringToHash("Dead");
    private int hitHash = Animator.StringToHash("Hit");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnAnimationEnd() => OnAnimationEndTrigger?.Invoke(); 
    public void OnAnimationEvent() => OnAnimationEventTrigger?.Invoke(); 

    public void SetSpeed(float speed) => animator.SetFloat(speedHash, speed);
    public void ToggleAttack(bool value) => animator.SetBool(onAttackHash, value);
    public void ToggleSubAttack(bool value) => animator.SetBool(onSubAttackHash, value);
    public void ToggleRolling(bool value) => animator.SetBool(onRollingHash, value);
    public void ToggleHit(bool value) => animator.SetBool(isHitHash, value);
    public void ToggleDead(bool value) => animator.SetBool(isDeadHash, value);
    public void SetHitTrigger(bool value) => SetTrigger(hitHash, value);
    public void SetDeadTrigger(bool value) => SetTrigger(deadHash, value);

    private void SetTrigger(int hash, bool value)
    {
        if(value)
            animator.SetTrigger(hash);
        else
            animator.ResetTrigger(hash);
    }
}
