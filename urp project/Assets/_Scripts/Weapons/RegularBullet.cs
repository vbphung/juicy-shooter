using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RegularBullet : Bullet
{
    public override BulletDataSO BulletData
    {
        get => base.BulletData;
        set
        {
            base.BulletData = value;
            rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.drag = BulletData.Friction;
        }
    }

    protected Rigidbody2D rigidbody;

    private void FixedUpdate()
    {
        if (rigidbody != null && BulletData != null)
            rigidbody.MovePosition(transform.position + BulletData.Speed * transform.right * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            HitObstacle();
        else if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            HitEnemy();
        Destroy(gameObject);
    }

    private void HitObstacle()
    {
        Debug.Log("hit");
    }

    private void HitEnemy()
    {
        Debug.Log("hit enemy");
    }
}