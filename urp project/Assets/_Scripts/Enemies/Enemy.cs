using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IHittable, IAgent, IKnockBack
{
    [SerializeField] [Range(0, 10)] float timeToDie;
    [SerializeField] EnemyDataSO enemyData;
    [SerializeField] EnemyAttack enemyAttack;

    [field: SerializeField] public UnityEvent OnGetHit { get; set; }
    [field: SerializeField] public UnityEvent OnDie { get; set; }

    public float Health { get; set; }

    private bool dead = false;
    private AgentMovement agentMovement;

    private void Awake()
    {
        if (enemyAttack == null)
            enemyAttack = GetComponent<EnemyAttack>();

        agentMovement = GetComponent<AgentMovement>();
    }

    private void Start()
    {
        Health = enemyData.MaxHealth;
    }

    public void GetHit(float damage, GameObject damageDealer)
    {
        if (!dead)
        {
            Health -= damage;

            if (Health <= 0)
            {
                dead = true;
                OnDie?.Invoke();
            }
            else
                OnGetHit?.Invoke();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void PerformAttack()
    {
        if (!dead)
            enemyAttack.Attack(enemyData.Damage);
    }

    public void KnockBack(Vector2 direction, float power, float duration)
    {
        agentMovement.KnockBack(direction, power, duration);
    }
}