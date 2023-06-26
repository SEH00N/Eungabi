using UnityEngine;

public class InnerDisatnceDecision : EnemyAIDecision
{
    [SerializeField] float distance = 5f;

    public override bool MakeDecision()
    {
        if(aiBrain.AIData.Target == null)
            return false;

        return ((aiBrain.AIData.Target.position - transform.position).magnitude < distance);
    }

    #if UNITY_EDITOR
    
    [SerializeField] Color gizmoColor = Color.red;

    private void OnDrawGizmosSelected()
    {
        if(UnityEditor.Selection.activeGameObject != gameObject)
            return;

        Color release = Gizmos.color;
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, distance);
        Gizmos.color = release;
    }

    #endif
}
