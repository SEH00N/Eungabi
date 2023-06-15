using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

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
}
