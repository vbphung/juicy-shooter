using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    protected AIActionData aIActionData;
    protected AIMovementData aIMovementData;
    protected EnemyBrain enemyBrain;

    private void Awake()
    {
        aIActionData = transform.root.GetComponentInChildren<AIActionData>();
        aIMovementData = transform.root.GetComponentInChildren<AIMovementData>();
        enemyBrain = transform.root.GetComponent<EnemyBrain>();
    }

    public abstract bool MakeDecision();
}