using System;
using System.Collections;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private static TimeController instance = null;
    public static TimeController Instance {
        get{
            if(instance == null)
                instance = FindObjectOfType<TimeController>();;

            return instance;
        }
    }

    public void ResetTimeScale()
    {
        StopAllCoroutines();
        Time.timeScale = 1;
    }

    public void ModifyTimeScale(float timeScale, float delay, Action callback = null)
    {
        StartCoroutine(TimeScaleCoroutine(timeScale, delay, callback));
    }

    private IEnumerator TimeScaleCoroutine(float timeScale, float delay, Action callback)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = timeScale;

        callback?.Invoke();    
    }
}
