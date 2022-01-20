using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet Data", menuName = "Weapon/Bullet Data", order = 0)]
public class BulletDataSO : ScriptableObject
{
    [field: SerializeField] [field: Range(0.1f, 100)] public float Friction { get; private set; }
    [field: SerializeField] [field: Range(1, 100)] public float Speed { get; private set; }
    [field: SerializeField] [field: Range(1, 100)] public float Damage { get; private set; }
    [field: SerializeField] [field: Range(1, 50)] public float KnockBackPower { get; private set; }
    [field: SerializeField] [field: Range(0.01f, 1f)] public float KnockBackDelay { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public GameObject ImpactObstaclePrefab { get; private set; }
    [field: SerializeField] public GameObject ImpactEnemyPrefab { get; private set; }
    [field: SerializeField] public bool Bounce { get; private set; }
    [field: SerializeField] public bool GoThroughHittable { get; private set; }
    [field: SerializeField] public bool IsRaycast { get; private set; }
}