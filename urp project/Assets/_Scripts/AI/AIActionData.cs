using UnityEngine;

public class AIActionData : MonoBehaviour
{
    [field: SerializeField] public bool Attack { get; private set; }
    [field: SerializeField] public bool TargetSpotted { get; set; }
    [field: SerializeField] public bool Arrived { get; private set; }
}