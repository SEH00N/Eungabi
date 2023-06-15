using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;
    public static UIManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<UIManager>();

            return instance;
        }
    }
    
    private Transform mainCanvasTrm = null;
    public Transform MainCanvasTrm {
        get {
            if(mainCanvasTrm == null)
                mainCanvasTrm = GameObject.Find("MainCanvas").transform;

            return mainCanvasTrm;
        }
    } 
    
    private DialogPanel dialogPanel = null;
    public DialogPanel DialogPanel {
        get {
            if(dialogPanel == null)
                dialogPanel = MainCanvasTrm.Find("DialogPanel").GetComponent<DialogPanel>();
        
            return dialogPanel;
        }
    }
}
