using System;
using System.Collections;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    [SerializeField] LayerMask opponentLayer = 1 << 7;
    [SerializeField] float dialogDistance = 2f;

    private Collider interlocutorCollider = null;
    private Interlocutor interlocutor = null;
    private DialogPanel dialogPanel = null;
    
    private StateHandler stateHandler = null;
    private PlayerMovement playerMovement = null;

    private void Awake()
    {
        dialogPanel = UIManager.Instance.DialogPanel;
        stateHandler = GetComponent<StateHandler>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        if (TryDetectInterlocutor(out interlocutorCollider))
        {
            if(dialogPanel.Focused == false)
                dialogPanel.Focus(true);

            dialogPanel.FocusPosition(DEFINE.MainCam.WorldToScreenPoint(interlocutorCollider.transform.position));
            //UI 띄우기
        }
        else
            if(dialogPanel.Focused == true)
                dialogPanel.Focus(false);

        // else if (interlocutorCollider == null)
        // {
        //     if (interlocutor != null)
        //     {
        //         interlocutor.EnactiveDialog();
        //         stateHandler.ChangeState(StateFlag.Normal);
        //         interlocutor = null;
        //     }
        // }
    }

    public void ActiveDialog()
    {
        if(interlocutorCollider == null)
            return;
        
        if (interlocutorCollider.TryGetComponent<Interlocutor>(out interlocutor) == false)
            return;

        Vector3 pos = (transform.position - interlocutor.transform.position).normalized * dialogDistance;
        pos -= (transform.position - interlocutor.transform.position);
        playerMovement.MoveImmediatly(pos);

        playerMovement.IsActiveRotate = false;
        playerMovement.StopImmediatly();
        playerMovement.SetRotation(interlocutor.transform.position);

        StartCoroutine(DelayCoroutine(0.1f, () => {
            interlocutor.ActiveDialog(() => {
                CameraManager.Instance.ActiveCamera(CameraType.MainCam);

                StartCoroutine(DelayCoroutine(1f, () => {
                    stateHandler.ChangeState(StateFlag.Normal);
                    interlocutor = null;
                }));
            });
            
            stateHandler.ChangeState(StateFlag.Interact);
        }));

    }

    private bool TryDetectInterlocutor(out Collider interlocutorCollider)
    {
        interlocutorCollider = null;
        Collider[] interlocutors = Physics.OverlapSphere(transform.position, dialogDistance, opponentLayer);

        if (interlocutors.Length > 0)
            interlocutorCollider = interlocutors[0];

        return interlocutors.Length > 0;
    }

    private IEnumerator DelayCoroutine(float delay, Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        if (UnityEditor.Selection.activeGameObject != gameObject)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dialogDistance);
    }

#endif
}
