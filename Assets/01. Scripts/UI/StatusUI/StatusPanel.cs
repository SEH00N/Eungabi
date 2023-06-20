using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class StatusPanel : MonoBehaviour
{
    private UIDocument uiDocument;

    private VisualElement statusPanel;
    private Label lightQuantity;
    private Label monsterQuantity;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        VisualElement root = uiDocument.rootVisualElement;

        statusPanel = root.Q("StatusPanel");

        lightQuantity = statusPanel.Q("RecordPanel").Q("LightBlock").Q<Label>("Quantity");
        monsterQuantity = statusPanel.Q("RecordPanel").Q("MonsterBlock").Q<Label>("Quantity");
    }

    private void Start()
    {
        SetLightQuantity(0);
        SetMonsterQuantity(0);
    }

    public void SetLightQuantity(int count) => lightQuantity.text = $"{count}";
    public void SetMonsterQuantity(int count) => monsterQuantity.text = $"{count}";

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(statusPanel.GetClasses().Contains("on"))
            {
                Time.timeScale = 1f;
                statusPanel.RemoveFromClassList("on");
            }
            else
            {
                Time.timeScale = 0f;
                statusPanel.AddToClassList("on");
            }
        }
    }
}
