using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class NavMovement : MonoBehaviour
{
    private NavMeshAgent navAgent = null;
    public NavMeshAgent NavAgent => navAgent;

    public UnityEvent<float> OnMovementEvent;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(navAgent.velocity.sqrMagnitude > 0)
            OnMovementEvent?.Invoke(IsArrived() ? 0f : 1f);
    }

    public bool IsArrived()
    {
        if(navAgent.pathPending == false && navAgent.remainingDistance <= navAgent.stoppingDistance + 0.5f)
            return true;
        else
            return false;
    }

    public void StopImmediately() => navAgent.SetDestination(transform.position);
    public void MoveToTarget(Vector3 targetPos) => navAgent.SetDestination(targetPos);
}
