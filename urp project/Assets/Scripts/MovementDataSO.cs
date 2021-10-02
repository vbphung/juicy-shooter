using UnityEngine;

[CreateAssetMenu(fileName = "New Movement Data", menuName = "Agent/Movement Data", order = 0)]
public class MovementDataSO : ScriptableObject
{
    [field: SerializeField] public float MaxSpeed { get; private set; }
    [field: SerializeField] public float Acceleration { get; private set; }
    [field: SerializeField] public float Deacceleration { get; private set; }
}