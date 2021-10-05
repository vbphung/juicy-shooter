using System;
using System.Collections;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    [field: SerializeField] [field: Range(0.1f, 10)] public float AttackDelay { get; private set; }

    protected EnemyBrain enemyBrain;
    protected bool waitBeforeNextAttack;

    private void Awake()
    {
        enemyBrain = GetComponent<EnemyBrain>();
    }

    public abstract void Attack(float damage);

    protected IEnumerator WaitBeforeAttack()
    {
        waitBeforeNextAttack = true;
        yield return new WaitForSeconds(AttackDelay);
        waitBeforeNextAttack = false;
    }

    protected GameObject GetTarget()
    {
        return enemyBrain.Target;
    }
}