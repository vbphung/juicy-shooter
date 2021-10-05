using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IHittable, IAgent
{
    [SerializeField] [Range(0, 10)] float timeToDie;
    [SerializeField] EnemyDataSO enemyData;

    [field: SerializeField] public UnityEvent OnGetHit { get; set; }
    [field: SerializeField] public UnityEvent OnDie { get; set; }

    public float Health { get; set; }

    private void Start()
    {
        Health = enemyData.MaxHealth;
    }

    public void GetHit(float damage, GameObject damageDealer)
    {
        Health -= damage;

        if (Health <= 0)
        {
            OnDie?.Invoke();
            StartCoroutine(WaitToDie());
        }
        else
            OnGetHit?.Invoke();
    }

    private IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(timeToDie);
        Destroy(gameObject);
    }
}