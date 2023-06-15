using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/DialogData")]
public class DialogDataSO : ScriptableObject
{
    public string InterlocutorName;
    public List<string> DialogSequence;
    public int DialogCount => DialogSequence.Count;
}