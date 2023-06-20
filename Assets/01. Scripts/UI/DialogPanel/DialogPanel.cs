using UnityEngine;
using UnityEngine.UIElements;

public class DialogPanel : MonoBehaviour
{
    private UIDocument uiDocument;

    [SerializeField] Transform focusCursor;
    private VisualElement dialogPanel;
    private Label textField;
    private Label nameField;

    private bool focused;
    public bool Focused => focused;

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

    private void Update()
    {
        if(Focused && dialogPanel != null)
        {
            focusCursor.rotation = Quaternion.Euler(0f, 0f, focusCursor.rotation.eulerAngles.z + (100f * Time.deltaTime));
        }
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

    public void Focus(bool active)
    {
        focused = active;

        focusCursor.gameObject.SetActive(active);
        focusCursor.rotation = Quaternion.identity;
    }

    public void FocusPosition(Vector2 screenPos)
    {
        focusCursor.position = screenPos;
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
