using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class EnemyAttackAction : EnemyAIAction
{
    [SerializeField] float attackCooldown = 1f;

    [SerializeField, Range(0, 1f)] float attackChance = 0.5f;
    [SerializeField, Range(0, 1f)] float[] patternWeights;

    private bool cooldown = false;
    private float timer = 0f;

    private int pattern = 0;

    public override void TakeAction()
    {
        if(cooldown)
        {
            timer += Time.deltaTime;
            navMovement.SetRotateDirection(aiBrain.AIData.Target.position - transform.position);

            if(timer >= attackCooldown)
            {
                timer = 0f;

                cooldown = false;
                aiBrain.AIData.OnAttack = false;
            }
        }

        if(aiBrain.AIData.OnAttack == false && cooldown == false)
        {
            float ratio = Random.value;
            if(ratio > attackChance)
            {
                pattern = DecidePattern();

                if(pattern == 0)
                    animator.ToggleAttack1(true);
                else if(pattern == 1)
                    animator.ToggleAttack2(true);
                else
                    animator.ToggleAttack3(true);
                
            }
            else
                cooldown = true;

            aiBrain.AIData.OnAttack = true;
        }
    }

    private int DecidePattern()
    {
        float total = 0f;

        for(int i = 0; i < patternWeights.Length; i++)
            total += patternWeights[i];

        float sum = 0f;
        float ratio = Random.Range(0, total);

        for(int i = 0; i < patternWeights.Length; i++)
            if(sum < ratio && ratio < sum + patternWeights[i])
                return i;
            else
                sum += patternWeights[i];

        return patternWeights.Length - 1;
    }

    public void RealseAnimation()
    {
        if (pattern == 0)
            animator.ToggleAttack1(false);
        else if (pattern == 1)
            animator.ToggleAttack2(false);
        else
            animator.ToggleAttack3(false);
    }

    public void SetCooldown(bool value) => cooldown = value;
    public void ToggleAttack(bool value) => aiBrain.AIData.OnAttack = value;
}
