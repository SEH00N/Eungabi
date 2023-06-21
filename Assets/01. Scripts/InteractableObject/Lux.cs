using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Lux : MonoBehaviour, IInteractable
{
    [SerializeField] int lightID = 0;
    [SerializeField] UnityEvent OnInteractEvent;

    private MeshRenderer meshRenderer = null;
    private Light emphasisLight = null;
    private MaterialPropertyBlock propBlock;

    private int intensityHash = Shader.PropertyToID("_Intensity");
    private int alphaHash = Shader.PropertyToID("_Alpha");

    private float materialIntensity = 0f;
    private float lightIntensity = 0f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        propBlock = new MaterialPropertyBlock();

        meshRenderer.GetPropertyBlock(propBlock);

        emphasisLight = transform.Find("EmphasisLight").GetComponent<Light>();
    }

    private void Start()
    {
        materialIntensity = meshRenderer.materials[0].GetFloat(intensityHash);
        lightIntensity = emphasisLight.intensity;
    }

    public void OnInteract(Transform performer)
    {
        //Debug.Log("interected");
        //Debug.Log("여기 나중에 풀링으로 바꿔라");
        OnInteractEvent?.Invoke();
    }

    public void Release()
    {
        Destroy(gameObject);
    }

    // private IEnumerator Disappear(float duration, System.Action callback = null)
    // {
    //     float timer = 0f;

    //     while (timer < duration)
    //     {
    //         emphasisLight.intensity = lightIntensity * (EaseInExpo(1f - timer / duration));

    //         propBlock.SetFloat(intensityHash, materialIntensity * EaseInExpo(1f - timer / duration));
    //         propBlock.SetFloat(alphaHash, 1f * EaseInExpo(1 - timer / duration));
    //         meshRenderer.SetPropertyBlock(propBlock);

    //         transform.position += Vector3.down * Time.deltaTime;

    //         timer += Time.deltaTime;
    //         yield return null;
    //     }

    //     emphasisLight.intensity = 0f;
    //     propBlock.SetFloat(intensityHash, 0f);
    //     propBlock.SetFloat(alphaHash, 0f);
    //     meshRenderer.SetPropertyBlock(propBlock);

    //     callback?.Invoke();
    // }

    // private float EaseInExpo(float t) => t == 0f ? 0f : Mathf.Pow(2f, 10f * t - 10f);
    // private float EaseOutExpo(float t) => t == 1f ? 1f : 1f - Mathf.Pow(2f, -10f * t);
    // private float EaseInOutExpo(float t) => 
    //     t == 0f 
    //     ? 0f
    //     : t == 1f
    //     ? 1f
    //     : t < 0.5f ? Mathf.Pow(2f, 20f * t - 10f) / 2f 
    //     : (2f - Mathf.Pow(2f, -20f * t + 10f)) / 2f;

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
