using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/DialogData")]
public class DialogDataSO : ScriptableObject
{
    public DialogData this[int idx] => DialogSequence[idx];

    public List<DialogData> DialogSequence;
    public int DialogCount => DialogSequence.Count;
}