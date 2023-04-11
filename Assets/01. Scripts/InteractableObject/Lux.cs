using UnityEngine;

public class Lux : MonoBehaviour, IInteractable
{
    public void OnInteract(Transform performer)
    {
        Debug.Log("여기 나중에 풀링으로 바꿔라");
        Destroy(gameObject);
    }

    #if UNITY_EDITOR
    
    private void OnDrawGizmosSelected()
    {
        Color previewColor = Gizmos.color;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.25f);

        Gizmos.color = previewColor;
    }

    #endif
}
