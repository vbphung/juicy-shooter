using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    [field: SerializeField] public List<AIDecision> Decisions { get; private set; }
    [field: SerializeField] public AIState PositiveResult { get; private set; }
    [field: SerializeField] public AIState NegativeResult { get; private set; }
}