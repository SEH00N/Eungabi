using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemyData")]
public class EnemyDataSO : ScriptableObject
{
    public int MaxHP = 5;
    public int StunTrigger = 3;
}
