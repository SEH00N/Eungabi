using System.Collections;
using UnityEngine;

public class EnemyPatrolAction : EnemyAIAction
{
    [SerializeField] float patrolRadius = 5f;
    [SerializeField] Vector2 postponeRange = new Vector2(5f, 10f);

    private Vector3 patrolPos;
    private bool stopFlag = false;

    public override void TakeAction()
    {
        if(navMovement.IsArrived() && stopFlag == false)
        {
            if(Random.Range(0, 3f) > 1f)
            {
                Vector2 randomUnitCircumion = RandomCircumion() * patrolRadius;
                patrolPos.x = randomUnitCircumion.x;
                patrolPos.z = randomUnitCircumion.y;

                navMovement.MoveToTarget(transform.position + patrolPos);
            }
            else
            {
                stopFlag = true;

                float delay = Random.Range(postponeRange.x, postponeRange.y);
                StartCoroutine(DelayCoroutine(delay, () => {
                    stopFlag = false;
                }));
            }
        }
    }

    private Vector2 RandomCircumion()
    {
        float angle = Random.Range(0f, 360f);
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    private IEnumerator DelayCoroutine(float delay, System.Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }
}
