using System;
using System.Collections;
using UnityEngine;

public class ButterflyNet : Weapon
{
    [SerializeField] Transform detectPos = null;
    [SerializeField] float detectRadius = 3f;
    [SerializeField] float startDelay = 0.3f;

    private PlayerStatus playerStatus = null;

    private void Awake()
    {
        playerStatus = transform.root.GetComponent<PlayerStatus>();
    }

    protected override void ActiveWeapon()
    {
        //Debug.Log("weapon actived");
        StartCoroutine(DelayCoroutine(startDelay, () => {
            if(DetectLux(out Lux lux))
            {
                lux.OnInteract(transform.root);
                playerStatus.LightQuantity++;
            }
        }));
    }

    private bool DetectLux(out Lux detectedLux)
    {
        detectedLux = null;

        Collider[] detectedColliders = Physics.OverlapSphere(detectPos.position, detectRadius, DEFINE.LuxLayer);
        foreach(Collider col in detectedColliders)
            if(col.TryGetComponent<Lux>(out detectedLux))
                return true;

        return false;
    }

    private IEnumerator DelayCoroutine(float delay, Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }

    #if UNITY_EDITOR
    
    private void OnDrawGizmosSelected()
    {
        Color previewColor = Gizmos.color;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(detectPos.position, detectRadius);

        Gizmos.color = previewColor;
    }

    #endif
}
