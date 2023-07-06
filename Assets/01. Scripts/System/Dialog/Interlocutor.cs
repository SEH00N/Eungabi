using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interlocutor : MonoBehaviour
{
    // [SerializeField] DialogDataSO dialogData;
    [SerializeField] List<DialogDataSO> dialogDatas;
    [SerializeField] List<DialogDecisionData> dialogDecisionDatas;
    [SerializeField] UnityEvent DialogEndEvent;

    private DialogPanel dialogPanel = null;
    // [SerializeField] bool hadDecision;
    // [SerializeField] UnityEvent PositiveDecisionEvent;
    // [SerializeField] UnityEvent NegativeDecisionEvent;
    
    private bool onDialog = false;
    public bool OnDialog => onDialog;

    private Action endOfDialogAction;

    private void Awake()
    {
        dialogPanel = UIManager.Instance.DialogPanel;
    }
    
    public void ActiveDialog(Action endOfDialog = null)
    {
        if(onDialog)
            return;
        
        dialogPanel.DisplayPanel(true);
        onDialog = true;

        endOfDialogAction = endOfDialog;
        
        // StartCoroutine(DialogCoroutine(dialogData.DialogSequence, dialogData.DialogCount, endOfDialog));
        StartCoroutine(DialogCoroutine());
    }
    
    public void EnactiveDialog()
    {
        StopAllCoroutines();
        onDialog = false;
        endOfDialogAction?.Invoke();
        dialogPanel.DisplayPanel(false);

        GameManager.Instance.GamePause = false;
    }

    private IEnumerator DialogCoroutine()
    {
        GameManager.Instance.GamePause = true;

        for(int i = 0; i < dialogDatas.Count; i++)
        {
            List<DialogData> dialogSequence = dialogDatas[i].DialogSequence;
            int dialogCount = dialogDatas[i].DialogCount;
            for(int j = 0; j < dialogCount; j++)
            {
                dialogPanel.SetInterlocutor(dialogSequence[j].interlocutorName);

                for(int k = 0; k < dialogSequence[j].DialogCount; k++)
                {
                    dialogPanel.SetTextContent(dialogSequence[j][k]);
                    yield return null;
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));
                }
            }

            if (dialogDecisionDatas != null && dialogDecisionDatas.Count > i && dialogDecisionDatas[i].hadDecision)
            {
                dialogPanel.CreateDecision(
                    () => dialogDecisionDatas[i].PositiveDecisionEvent?.Invoke(), 
                    () => dialogDecisionDatas[i].NegativeDecisionEvent?.Invoke()
                );
                yield return new WaitUntil(() => dialogPanel.EndDecision);
            }
        }

        onDialog = false;
        dialogPanel.DisplayPanel(false);
        endOfDialogAction?.Invoke();
        DialogEndEvent?.Invoke();

        GameManager.Instance.GamePause = false;
    }

    // private IEnumerator DialogCoroutine(List<DialogData> dialogSequence, int dialogCount, Action endOfDialog)
    // {
    //     for(int i = 0; i < dialogCount; i++)
    //     {
    //         dialogPanel.SetInterlocutor(dialogSequence[i].interlocutorName);

    //         for(int j = 0; j < dialogSequence[i].DialogCount; j++)
    //         {
    //             dialogPanel.SetTextContent(dialogSequence[i][j]);
    //             yield return null;
    //             yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));
    //         }
    //     }

    //     if(hadDecision)
    //     {
    //         dialogPanel.CreateDecision(() => PositiveDecisionEvent?.Invoke(), () => NegativeDecisionEvent?.Invoke());
    //         yield return new WaitUntil(() => dialogPanel.EndDecision);
    //     }

    //     onDialog = false;
    //     dialogPanel.DisplayPanel(false);
    //     endOfDialog?.Invoke();
    //     DialogEndEvent?.Invoke();
    // }
}
