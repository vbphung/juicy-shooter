using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    [field: SerializeField] public AIState PositiveResult { get; private set; }
    [field: SerializeField] public AIState NegativeResult { get; private set; }

    public List<AIDecision> Decisions { get; private set; }

    private void Awake()
    {
        if (Decisions != null)
            Decisions.Clear();

        Decisions = new List<AIDecision>(GetComponents<AIDecision>());
    }
}