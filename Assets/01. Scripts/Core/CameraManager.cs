using System.Runtime.InteropServices;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using System;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    private static CameraManager instance = null;
    public static CameraManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<CameraManager>();

            return instance;
        }
    }

    private Dictionary<CameraType, CinemachineVirtualCamera> cmVCamDictionary;

    private CinemachineVirtualCamera activedCam = null;
    private CinemachineBasicMultiChannelPerlin mainCamPerlin;

    private void Awake()
    {
        cmVCamDictionary = new Dictionary<CameraType, CinemachineVirtualCamera>();
        Transform cmVCamTrm = GameObject.Find("CMVCam").transform;

        foreach(CameraType type in typeof(CameraType).GetEnumValues())
        {
            if(cmVCamDictionary.ContainsKey(type))
            {
                Debug.LogWarning($"current type of camera is already existed on dictionary");
                continue;
            }

            CinemachineVirtualCamera cmVCam = cmVCamTrm.Find($"CM{type.ToString()}")?.GetComponent<CinemachineVirtualCamera>();
            if(cmVCam != null)
                cmVCamDictionary.Add(type, cmVCam);
        }

        mainCamPerlin = cmVCamDictionary[CameraType.MainCam].GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        ActiveCamera(CameraType.MainCam);
    }

    public void ActiveCamera(CameraType type)
    {
        if(cmVCamDictionary.ContainsKey(type) == false)
            return;

        if(activedCam != null)
            activedCam.m_Priority = 5;

        activedCam = cmVCamDictionary[type];
        activedCam.m_Priority = 15;
    }

    /// <param name="time">시간</param>
    /// <param name="amplitude">진폭</param>
    /// <param name="frequency">진동수</param>
    public void ShakeCam(float time, float amplitude, float frequency)
    {
        mainCamPerlin.m_AmplitudeGain = amplitude;
        mainCamPerlin.m_FrequencyGain = frequency;

        StartCoroutine(DelayCoroutine(time, () => ShakeCam(0, 0)));
    }

    public void ShakeCam(float amplitude, float frequency)
    {
        mainCamPerlin.m_AmplitudeGain = amplitude;
        mainCamPerlin.m_FrequencyGain = frequency;
    }

    public void ResetShake()
    {
        StopAllCoroutines();
        if(mainCamPerlin != null)
            ShakeCam(0, 0);
    }

    private IEnumerator DelayCoroutine(float delay, Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }
}
