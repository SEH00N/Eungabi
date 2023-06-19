using System.Collections.Generic;
using UnityEngine;

public class StageEntrance : MonoBehaviour
{
    [SerializeField] int stageNumber = 0;
    [SerializeField] List<GameObject> lights = new List<GameObject>();

    [Space(10f)]
    [SerializeField] Light statusLight = null;
    [SerializeField] Color enactiveColor;
    [SerializeField] Color activeColor;

    private StageData stageData = null;

    private void Start()
    {
        stageData = DataManager.Instance.StageData;
        if(stageData.StageCount == 0)
        {
            stageData.StageCount = 2;
            stageData.StageInfo = new List<List<bool>>();

            for(int i = 0; i < stageData.StageCount; i++)
            {
                stageData.StageInfo.Add(new List<bool>());
                stageData.StageClearInfo.Add(false);
            }
        }

        SetStageClearState(stageData.StageClearInfo[stageNumber]);
    }

    public void SetStageClearState(bool state)
    {
        lights.ForEach(light => light.SetActive(state));
        statusLight.color = state ? activeColor : enactiveColor;
    }
}
