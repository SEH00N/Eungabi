using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interlocutor : MonoBehaviour
{
    [SerializeField] DialogDataSO dialogData;
    [SerializeField] UnityEvent DialogEndEvent;
    private DialogPanel dialogPanel = null;
    
    private bool onDialog = false;
    public bool OnDialog => onDialog;

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
        
        StartCoroutine(DialogCoroutine(dialogData.DialogSequence, dialogData.DialogCount, endOfDialog));
    }
    
    public void EnactiveDialog()
    {
        StopAllCoroutines();
        onDialog = false;
        dialogPanel.DisplayPanel(false);
    }

    private IEnumerator DialogCoroutine(List<DialogData> dialogSequence, int dialogCount, Action endOfDialog)
    {
        for(int i = 0; i < dialogCount; i++)
        {
            dialogPanel.SetInterlocutor(dialogSequence[i].interlocutorName);

            for(int j = 0; j < dialogSequence[i].DialogCount; j++)
            {
                dialogPanel.SetTextContent(dialogSequence[i][j]);
                yield return null;
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));
            }
        }

        onDialog = false;
        dialogPanel.DisplayPanel(false);
        endOfDialog?.Invoke();
        DialogEndEvent?.Invoke();
    }
}
