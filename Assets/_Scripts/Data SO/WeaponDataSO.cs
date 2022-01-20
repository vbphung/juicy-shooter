using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Weapon/Weapon Data", order = 0)]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField] public int AmmoCapacity { get; private set; }
    [field: SerializeField] public int BulletCountToSpawn { get; private set; }
    [field: SerializeField] public bool AutomaticFire { get; private set; }
    [field: SerializeField] public float WeaponDelay { get; private set; }
    [field: SerializeField] public float SpreadAngle { get; private set; }
    [field: SerializeField] public BulletDataSO BulletData { get; private set; }
}