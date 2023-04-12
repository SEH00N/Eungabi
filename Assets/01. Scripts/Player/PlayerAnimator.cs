using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public event Action OnAnimationEndTrigger = null;

    private Animator animator = null;

    private int speedHash = Animator.StringToHash("Speed");
    private int onAttackHash = Animator.StringToHash("OnAttack");
    private int onSubAttackHash = Animator.StringToHash("OnSubAttack");
    private int onRollingHash = Animator.StringToHash("OnRolling");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnAnimationEnd() => OnAnimationEndTrigger?.Invoke(); 

    public void SetSpeed(float speed) => animator.SetFloat(speedHash, speed);
    public void ToggleAttack(bool value) => animator.SetBool(onAttackHash, value);
    public void ToggleSubAttack(bool value) => animator.SetBool(onSubAttackHash, value);
    public void ToggleRolling(bool value) => animator.SetBool(onRollingHash, value);
}
