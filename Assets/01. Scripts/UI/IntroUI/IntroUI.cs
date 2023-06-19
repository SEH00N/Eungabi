using UnityEngine;
using UnityEngine.UIElements;


public class IntroUI : MonoBehaviour
{
    private UIDocument uiDocument;

    private VisualElement startButton;
    private VisualElement optionButton;
    private VisualElement exitButton;

    private void OnEnable()
    {
        VisualElement root = uiDocument.rootVisualElement;
        VisualElement buttonContainer = root.Q("Container").Q("MenuBG").Q("ButtonContainer");

        startButton = buttonContainer.Q("StartButton");
        optionButton = buttonContainer.Q("OptionButton");
        exitButton = buttonContainer.Q("ExitButton");

        startButton.RegisterCallback<ClickEvent>(evt => {
            Debug.Log("게임 시작");
        });

        optionButton.RegisterCallback<ClickEvent>(evt => {
            Debug.Log("옵션 창");
        });

        exitButton.RegisterCallback<ClickEvent>(evt => {
            Debug.Log("게임 종료");
        });
    }
}
