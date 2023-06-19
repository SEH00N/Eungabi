using UnityEngine;
using UnityEngine.UIElements;


public class IntroUI : MonoBehaviour
{
    private UIDocument uiDocument;

    private VisualElement startButton;
    private VisualElement optionButton;
    private VisualElement exitButton;

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
            Debug.Log("게임 시작");
        });

        optionButton.RegisterCallback<MouseDownEvent>(evt => {
            Debug.Log("옵션 창");
        });

        exitButton.RegisterCallback<MouseDownEvent>(evt => {
            Debug.Log("게임 종료");
        });
    }
}
