using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;


public class IntroUI : MonoBehaviour
{
    private UIDocument uiDocument;

    private VisualElement startButton;
    private VisualElement optionButton;
    private VisualElement exitButton;

    [SerializeField] UnityEvent StartButtonClicked;
    [SerializeField] UnityEvent OptionButtonClicked;
    [SerializeField] UnityEvent ExitButtonClicked;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        VisualElement root = uiDocument.rootVisualElement;
        VisualElement buttonContainer = root.Q("Container").Q("MenuBG").Q("ButtonContainer");

        startButton = buttonContainer.Q("StartButton");
        optionButton = buttonContainer.Q("OptionButton");
        exitButton = buttonContainer.Q("ExitButton");

        startButton.RegisterCallback<MouseDownEvent>(evt => {
            StartButtonClicked?.Invoke();
        });

        optionButton.RegisterCallback<MouseDownEvent>(evt => {
            OptionButtonClicked?.Invoke();
        });

        exitButton.RegisterCallback<MouseDownEvent>(evt => {
            ExitButtonClicked?.Invoke();
        });
    }
}
