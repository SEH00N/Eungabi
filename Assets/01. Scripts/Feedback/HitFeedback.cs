using UnityEngine;

public class HitFeedback : MonoBehaviour
{
    [SerializeField] PoolableMono hitParticle = null;

    public void CreateFeedback(Vector3 point, Vector3 normal)
    {
        // Debug.Break();
        // Debug.Log($"point : {point} | normal : {normal}");
        Effect effect = PoolManager.Instance.Pop(hitParticle) as Effect;
        effect.transform.position = point;
        effect.transform.rotation = Quaternion.LookRotation(normal);

        effect.PlayEffects();
    }

    public void FinishFeedback()
    {
        
    }
}
