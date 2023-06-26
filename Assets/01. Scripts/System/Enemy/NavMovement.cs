using UnityEngine;
using UnityEngine.AI;

public class NavMovement : MonoBehaviour
{
    private NavMeshAgent navAgent = null;
    public NavMeshAgent NavAgent => navAgent;

    private AnimatorHandler animator = null;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = transform.Find("Model").GetComponent<AnimatorHandler>();
    }

    private void Update()
    {
        //if(navAgent.velocity.sqrMagnitude > 0)
            animator?.SetSpeed(IsArrived() ? 0f : 1f);
    }

    public bool IsArrived()
    {
        if(navAgent.pathPending == false && navAgent.remainingDistance <= navAgent.stoppingDistance + 0.5f)
            return true;
        else
            return false;
    }

    public bool AbleToMove(Vector3 destination)
    {
        NavMeshPath path = new NavMeshPath();
        navAgent.CalculatePath(destination, path);

        return path.status != NavMeshPathStatus.PathPartial;
    }

    public void StopImmediately() => navAgent.SetDestination(transform.position);
    public void MoveToTarget(Vector3 targetPos) => navAgent.SetDestination(targetPos);

    #if UNITY_EDITOR
    
    [SerializeField] Color gizmoColor = Color.red;

    private void OnDrawGizmosSelected()
    {
        if(UnityEditor.Selection.activeGameObject != gameObject)
            return;

        if(navAgent == null)
            return;

        Color release = Gizmos.color;
        Gizmos.color = gizmoColor;
        Gizmos.DrawLine(transform.position, navAgent.destination);
        Gizmos.color = release;
    }

    #endif
}
