using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.VFX;

public class Effect : PoolableMono
{
    [SerializeField] List<ParticleSystem> particles = null;
    [SerializeField] List<VisualEffect> effects = null;

    private void OnDestroy()
    {
        Debug.Log("Destroyed");
    }

    public override void Init()
    {
        StopEffects();
    }

    public void PlayEffects(float playTime = 1f)
    {
        particles?.ForEach(p => p.Play());
        effects?.ForEach(e => e.Play());
        StartCoroutine(DelayCoroutine(0.7f, () => Debug.Log("0.7초 경과")));
        StartCoroutine(DelayCoroutine(0.95f, () => Debug.Log("0.95초 경과")));
        StartCoroutine(DelayCoroutine(1f, () => Debug.Log("1초 경과")));
        StartCoroutine(DelayCoroutine(playTime, () => {
            StopEffects();
            PoolManager.Instance.Push(this);
        }));
    }

    public void StopEffects()
    {
        particles?.ForEach(p => {
            p.Stop();
            p.Simulate(0);
        });
        effects?.ForEach(e => {
            e.Stop();
            e.Simulate(0);
        });
    }

    private IEnumerator DelayCoroutine(float delay, Action callback = null)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }
}
