using UnityEngine;

public class EnemyGroggyAction : EnemyAIAction
{
    [SerializeField] float groggyTime = 1.5f;
    [SerializeField] AIState targetState;

    private float timer = 0f;

    public override void TakeAction()
    {
        timer += Time.deltaTime;

        if(timer > groggyTime)
            aiBrain.ChangeState(targetState);
    }

    public void ResetTimer()
    {
        timer = 0f;
    }
}
