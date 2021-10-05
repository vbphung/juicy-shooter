using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IHittable, IAgent
{
    [SerializeField] [Range(0, 10)] float timeToDie;
    [SerializeField] EnemyDataSO enemyData;
    [SerializeField] EnemyAttack enemyAttack;

    [field: SerializeField] public UnityEvent OnGetHit { get; set; }
    [field: SerializeField] public UnityEvent OnDie { get; set; }

    public float Health { get; set; }

    private bool dead = false;

    private void Awake()
    {
        if (enemyAttack == null)
            enemyAttack = GetComponent<EnemyAttack>();
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
                StartCoroutine(WaitToDie());
            }
            else
                OnGetHit?.Invoke();
        }
    }

    private IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(timeToDie);
        Destroy(gameObject);
    }

    public void PerformAttack()
    {
        if (!dead)
            enemyAttack.Attack(enemyData.Damage);
    }
}