using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent
{
    [field: SerializeField] public UnityEvent OnGetHit { get; set; }
    [field: SerializeField] public UnityEvent OnDie { get; set; }

    public float Health { get; set; }
}