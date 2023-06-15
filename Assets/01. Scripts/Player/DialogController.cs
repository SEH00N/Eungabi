using System;
using System.Collections;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    [SerializeField] LayerMask opponentLayer = 1 << 7;
    [SerializeField] float dialogDistance = 5f;

    private Collider interlocutorCollider = null;
    private Interlocutor interlocutor = null;
    private DialogPanel dialogPanel = null;
    private StateHandler stateHandler = null;

    private void Awake()
    {
        dialogPanel = UIManager.Instance.DialogPanel;
        stateHandler = GetComponent<StateHandler>();
    }

    private void Update()
    {
        if (TryDetectInterlocutor(out interlocutorCollider))
        {
            //UI 띄우기
        }
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
        if(interlocutorCollider != null)
        {
            if (interlocutorCollider.TryGetComponent<Interlocutor>(out interlocutor))
            {
                interlocutor.ActiveDialog(() => {
                    CameraManager.Instance.ActiveCamera(CameraType.MainCam);

                    StartCoroutine(DelayCoroutine(1f, () => {
                        stateHandler.ChangeState(StateFlag.Normal);
                        interlocutor = null;
                    }));
                });
                stateHandler.ChangeState(StateFlag.Interact);
            }
        }
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
        if (UnityEditor.Selection.activeGameObject != this)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dialogDistance);
    }

#endif
}
