using UnityEngine;

public class BoxingGun : Weapon
{
    [SerializeField] Transform detectPos;
    [SerializeField] float detectRadius;

    private Animator animator = null;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected override void ActiveWeapon()
    {
        animator.SetBool("OnAttack", true);
    }

    public void OnAnimationEnd()
    {
        animator.SetBool("OnAttack", false);
    }

    public void OnAnimationEvent()
    {
        Debug.Log("받아랏");
        RaycastHit[] hits = DetectEnemy();
        
        foreach(RaycastHit hit in hits)
            if(hit.transform.TryGetComponent<IDamageable>(out IDamageable id))
                id?.OnDamage(1, transform.root, hit.point, hit.normal);
    }

    private RaycastHit[] DetectEnemy()
    {
        Vector3 startPos = detectPos.position - detectPos.forward * detectRadius;
        float distance = detectRadius * 3f;

        RaycastHit[] hits = Physics.SphereCastAll(startPos, detectRadius, detectPos.forward, distance, DEFINE.EnemyLayer);

        return hits;
    }
}
