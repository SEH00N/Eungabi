using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    [SerializeField] float castingRadius = 2f;
    [SerializeField, Range(1f, 3f)] float castingInterpolation = 1f;
    [SerializeField] LayerMask castingLayer = 1 << 3;

    public void CastDamage(int damage)
    {
        Vector3 startPos = transform.position - transform.forward * castingRadius;
        RaycastHit[] hits = Physics.SphereCastAll(startPos, castingRadius, transform.forward, castingRadius * castingInterpolation, castingLayer);

        foreach(RaycastHit hit in hits)
        {
            if (hit.collider.TryGetComponent<IDamageable>(out IDamageable id))
            {
                if(hit.point.sqrMagnitude == 0)
                    continue;

                id.OnDamage(damage, transform.parent, hit.point, hit.normal);
            }
        }
    }

    #if UNITY_EDITOR
    
    [SerializeField] Color gizmoColor = Color.cyan;

    private void OnDrawGizmosSelected()
    {
        if(UnityEditor.Selection.activeGameObject != gameObject)
            return;

        Color release = Gizmos.color;
        Gizmos.color = gizmoColor;

        Vector3 startPos = transform.position - transform.forward * castingRadius;

        Gizmos.DrawLine(startPos, startPos + transform.forward * castingRadius * castingInterpolation);
        Gizmos.DrawWireSphere(startPos + transform.forward * castingRadius * castingInterpolation, castingRadius);

        Gizmos.color = release;
    }

    #endif
}
