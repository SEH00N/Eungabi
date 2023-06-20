using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogPanel : MonoBehaviour
{
    private UIDocument uiDocument;

    private VisualElement dialogPanel;
    private VisualElement focusCursor;
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
        
        focusCursor = root.Q("FocusCursor");
    }

    private void Update()
    {
        if(Focused && dialogPanel != null)
        {
            dialogPanel.transform.rotation = Quaternion.Euler(0f, 0f, dialogPanel.transform.rotation.eulerAngles.z + (10f * Time.deltaTime));
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
        if(active)
            focusCursor.AddToClassList("on");
        else
            focusCursor.RemoveFromClassList("on");
    }

    public void FocusPosition(Vector2 screenPos)
    {
        focusCursor.style.left = screenPos.x;
        focusCursor.style.right = screenPos.y;
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
