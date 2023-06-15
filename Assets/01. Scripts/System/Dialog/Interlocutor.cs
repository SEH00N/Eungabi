using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interlocutor : MonoBehaviour
{
    [SerializeField] DialogDataSO dialogData;
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
        
        dialogPanel.SetInterlocutor(dialogData.InterlocutorName);
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

    private IEnumerator DialogCoroutine(List<string> dialogSequence, int dialogCount, Action endOfDialog)
    {
        for(int i = 0; i < dialogCount; i++)
        {
            dialogPanel.SetTextContent(dialogSequence[i]);
            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));
        }

        onDialog = false;
        dialogPanel.DisplayPanel(false);
        endOfDialog?.Invoke();
    }
}
