using UnityEngine;
using UnityEngine.AI;

public class NavMovement : MonoBehaviour
{
    private NavMeshAgent navAgent = null;
    public NavMeshAgent NavAgent => navAgent;

    private AnimatorHandler animator = null;

    private Vector3 rotateDirection;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = transform.Find("Model").GetComponent<AnimatorHandler>();
    }

    private void Update()
    {
        animator?.SetSpeed(IsArrived() ? 0f : 1f);
        navAgent.isStopped = GameManager.Instance.GamePause;
    }

    private void FixedUpdate()
    {
        if(navAgent.updateRotation || GameManager.Instance.GamePause)
            return;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotateDirection), Time.deltaTime * 10f);
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
    
    public void RotateImmediately(Vector3 dir)
    {
        SetRotateDirection(dir);
        transform.rotation = Quaternion.LookRotation(rotateDirection);
    }

    public void AutoRotate(bool value) => navAgent.updateRotation = value;

    public void StopImmediately() => navAgent.SetDestination(transform.position);
    public void MoveToTarget(Vector3 targetPos) => navAgent.SetDestination(targetPos);
    public void SetRotateDirection(Vector3 dir) => rotateDirection = dir;

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
