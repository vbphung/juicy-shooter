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
            myRigidbody = GetComponent<Rigidbody2D>();
            myRigidbody.drag = BulletData.Friction;
        }
    }

    protected Rigidbody2D myRigidbody;

    private void FixedUpdate()
    {
        if (myRigidbody != null && BulletData != null)
            myRigidbody.MovePosition(transform.position + BulletData.Speed * transform.right * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var hittable = collider.GetComponent<IHittable>();
        hittable?.GetHit(BulletData.Damage, null);

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