using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LuxCollectFeedback : Feedback
{
    [SerializeField] UnityEvent EndOfFeedback;

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

    public override void CreateFeedback()
    {
        
    }

    public override void FinishFeedback()
    {
        
    }

    private IEnumerator Disappear(float duration, System.Action callback = null)
    {
        float timer = 0f;

        while (timer < duration)
        {
            emphasisLight.intensity = lightIntensity * (EaseInExpo(1f - timer / duration));

            propBlock.SetFloat(intensityHash, materialIntensity * EaseInExpo(1f - timer / duration));
            propBlock.SetFloat(alphaHash, 1f * EaseInExpo(1 - timer / duration));
            meshRenderer.SetPropertyBlock(propBlock);

            transform.position += Vector3.down * Time.deltaTime;

            timer += Time.deltaTime;
            yield return null;
        }

        emphasisLight.intensity = 0f;
        propBlock.SetFloat(intensityHash, 0f);
        propBlock.SetFloat(alphaHash, 0f);
        meshRenderer.SetPropertyBlock(propBlock);

        callback?.Invoke();
    }

    private float EaseInExpo(float t) => t == 0f ? 0f : Mathf.Pow(2f, 10f * t - 10f);
}
