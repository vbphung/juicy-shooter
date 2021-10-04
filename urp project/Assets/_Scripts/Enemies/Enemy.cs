using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IHittable
{
    [field: SerializeField] public float Health { get; private set; }
    [field: SerializeField] public UnityEvent OnGetHit { get; set; }

    public void GetHit(int damage, GameObject damageDealer)
    {
        --Health;
        OnGetHit?.Invoke();

        if (Health <= 0)
            Destroy(gameObject);
    }
}