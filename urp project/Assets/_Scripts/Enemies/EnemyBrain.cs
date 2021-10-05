using UnityEngine;
using UnityEngine.Events;

public class EnemyBrain : MonoBehaviour, IAgentInput
{
    [SerializeField] public AIState startState;

    [field: SerializeField] public UnityEvent<Vector2> OnMovementKeyPress { get; set; }
    [field: SerializeField] public UnityEvent<Vector2> OnPointerPositionChanged { get; set; }
    [field: SerializeField] public UnityEvent OnFireButtonPressed { get; set; }
    [field: SerializeField] public UnityEvent OnFireButtonReleased { get; set; }

    public GameObject Target { get; private set; }
    public AIState CurrentState { get; private set; }

    private void Awake()
    {
        Target = FindObjectOfType<Player>().gameObject;
        ChangeToState(startState);
    }

    private void Update()
    {
        if (Target == null)
            OnMovementKeyPress?.Invoke(Vector2.zero);

        CurrentState.UpdateState();
    }

    public void Attack()
    {
        OnFireButtonPressed?.Invoke();
    }

    public void Move(Vector2 moveDirection, Vector2 targetPosition)
    {
        OnMovementKeyPress?.Invoke(moveDirection);
        OnPointerPositionChanged?.Invoke(targetPosition);
    }

    public void ChangeToState(AIState state)
    {
        CurrentState = state;
    }
}