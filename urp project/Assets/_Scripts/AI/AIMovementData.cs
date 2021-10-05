using UnityEngine;

public class AIMovementData : MonoBehaviour
{
    [field: SerializeField] public Vector2 Direction { get; private set; }
    [field: SerializeField] public Vector2 PointOfInterest { get; private set; }
}