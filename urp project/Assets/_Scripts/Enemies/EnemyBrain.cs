using UnityEngine;
using UnityEngine.Events;

public class EnemyBrain : MonoBehaviour, IAgentInput
{
    [field: SerializeField] public UnityEvent<Vector2> OnMovementKeyPress { get; set; }
    [field: SerializeField] public UnityEvent<Vector2> OnPointerPositionChanged { get; set; }
    [field: SerializeField] public UnityEvent OnFireButtonPressed { get; set; }
    [field: SerializeField] public UnityEvent OnFireButtonReleased { get; set; }

    public GameObject Target { get; private set; }

    private void Awake()
    {
        Target = FindObjectOfType<Player>().gameObject;
    }
}