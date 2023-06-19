using UnityEngine;
using UnityEngine.UIElements;

public class DialogPanel : MonoBehaviour
{
    private UIDocument uiDocument;

    private VisualElement dialogPanel;
    private Label textField;
    private Label nameField;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        VisualElement root = uiDocument.rootVisualElement;

        dialogPanel = root.Q("DialogPanel");
        textField = dialogPanel.Q<Label>("TextField");
        nameField = dialogPanel.Q<Label>("NameField");
    }


    public void SetInterlocutor(string name)
    {
        nameField.text = name;
    }

    public void SetTextContent(string content)
    {
        textField.text = content;
    }

    public void DisplayPanel(bool value)
    {
        if (value)
            dialogPanel.AddToClassList("on");
        else
            dialogPanel.RemoveFromClassList("on");
    }
}
    // [SerializeField] string nameT;
    // [SerializeField] string contentT;
    // private bool a;
    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.LeftControl))
    //     {
    //         DisplayPanel(a);
    //         Debug.Log(a);
    //         a = !a;
    //     }

    //     if (Input.GetKeyDown(KeyCode.LeftShift))
    //     {
    //         SetInterlocutor(nameT);
    //         SetTextContent(contentT);
    //     }
    // }
