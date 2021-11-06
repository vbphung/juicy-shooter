using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [SerializeField] float maxHealth;
    [field: SerializeField] public UnityEvent OnGetHit { get; set; }
    [field: SerializeField] public UnityEvent OnDie { get; set; }

    public float Health { get; set; }

    private bool isDead = false;

    private void Awake()
    {
        Health = maxHealth;
    }

    public void GetHit(float damage, GameObject damageDealer)
    {
        if (!isDead)
        {
            Health -= damage;
            if (Health <= 0)
            {
                isDead = true;
                OnDie?.Invoke();
            }
            else
                OnGetHit?.Invoke();
        }
    }
}