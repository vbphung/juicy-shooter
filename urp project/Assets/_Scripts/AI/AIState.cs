using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    [SerializeField] private List<AIAction> actions;
    [SerializeField] private List<AITransition> transitions;

    private EnemyBrain enemyBrain;

    private void Awake()
    {
        enemyBrain = transform.root.GetComponent<EnemyBrain>();
    }

    public void UpdateState()
    {
        foreach (var action in actions)
            action.TakeAction();

        foreach (var transition in transitions)
        {
            bool result = false;
            foreach (var decision in transition.Decisions)
            {
                result = decision.MakeDecision();
                if (!result)
                    break;
            }

            if (result)
            {
                if (transition.PositiveResult != null)
                {
                    enemyBrain.ChangeToState(transition.PositiveResult);
                    return;
                }
            }
            else if (transition.NegativeResult != null)
            {
                enemyBrain.ChangeToState(transition.NegativeResult);
                return;
            }
        }
    }
}