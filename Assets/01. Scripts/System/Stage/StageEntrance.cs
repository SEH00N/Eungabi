using System.Collections.Generic;
using UnityEngine;

public class StageEntrance : MonoBehaviour
{
    [SerializeField] List<GameObject> lights = new List<GameObject>();

    public void SetStageClearState(bool state)
    {
        lights.ForEach(light => light.SetActive(state));
    }
}
