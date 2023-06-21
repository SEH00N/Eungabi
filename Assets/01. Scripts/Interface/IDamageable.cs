using UnityEngine;

public interface IDamageable
{
    public int MaxHP { get; }
    public int CurrentHP { get; }

    public void OnDamage(int damage, Transform performer = null, Vector3 position = default, Vector3 normal = default);
}