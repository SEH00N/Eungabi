using System.Collections.Generic;

[System.Serializable]
public struct DialogData
{
    public string this[int idx] => dialogSequence[idx];

    public string interlocutorName;
    public List<string> dialogSequence;
    
    public int DialogCount => dialogSequence.Count;
}
