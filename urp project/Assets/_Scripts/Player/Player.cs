using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [SerializeField] float maxHealth;
    [field: SerializeField] public UnityEvent OnGetHit { get; set; }
    [field: SerializeField] public UnityEvent OnDie { get; set; }

    public float Health { get; set; }

    private PlayerWeapon playerWeapon;
    private bool isDead = false;

    private void Awake()
    {
        Health = maxHealth;
        playerWeapon = GetComponentInChildren<PlayerWeapon>();
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Resource"))
        {
            var resource = collider.gameObject.GetComponent<Resource>();
            if (resource != null)
                switch (resource.ResourceData.Type)
                {
                    case ResourceType.Ammo:
                        if (!playerWeapon.FullAmmo)
                        {
                            playerWeapon.ReloadAmmo(resource.ResourceData.Amount);
                            resource.PickUp();
                        }

                        break;
                    case ResourceType.Health:
                        Health = Mathf.Clamp(Health + resource.ResourceData.Amount, 0, maxHealth);
                        resource.PickUp();
                        break;
                }
        }
    }
}