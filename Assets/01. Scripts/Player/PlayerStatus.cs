using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private int lightQuantity;
    public int LightQuantity {
        get => lightQuantity;
        set {
            lightQuantity = value;
            statusPanel.SetLightQuantity(lightQuantity);
        }
    }

    private int monsterQuantity;
    public int MonsterQuantity {
        get => monsterQuantity;
        set {
            monsterQuantity = value;
            statusPanel.SetMonsterQuantity(monsterQuantity);
        }
    }

    private StatusPanel statusPanel = null;

    private void Awake()
    {
        statusPanel = UIManager.Instance.StatusPanel;
    }
}
