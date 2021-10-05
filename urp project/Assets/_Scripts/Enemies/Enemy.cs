using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IHittable
{
    [SerializeField] [Range(0, 10)] float timeToDie;

    [field: SerializeField] public float Health { get; private set; }
    [field: SerializeField] public UnityEvent OnGetHit { get; set; }
    [field: SerializeField] public UnityEvent OnDie { get; set; }

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