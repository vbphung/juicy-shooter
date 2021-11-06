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
    private bool exploded = false;

    private void FixedUpdate()
    {
        if (myRigidbody != null && BulletData != null)
            myRigidbody.MovePosition(transform.position + BulletData.Speed * transform.right * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!exploded)
        {
            exploded = true;

            var hittable = collider.GetComponent<IHittable>();
            hittable?.GetHit(BulletData.Damage, null);

            if (collider.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
                HitObstacle(collider);
            else if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                HitEnemy(collider);
            Destroy(gameObject);
        }
    }

    private void HitObstacle(Collider2D collider)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        if (hit.collider != null)
            Instantiate(BulletData.ImpactObstaclePrefab, hit.point, Quaternion.identity);
    }

    private void HitEnemy(Collider2D collider)
    {
        var knockBack = collider.GetComponent<IKnockBack>();
        knockBack.KnockBack(transform.right, BulletData.KnockBackPower, BulletData.KnockBackDelay);

        Vector2 randomOffset = Random.insideUnitCircle * 0.5f;
        Instantiate(BulletData.ImpactEnemyPrefab, collider.transform.position + (Vector3)randomOffset, Quaternion.identity);
    }
}