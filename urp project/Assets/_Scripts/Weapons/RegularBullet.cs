using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RegularBullet : Bullet
{
    protected Rigidbody2D rigidbody;

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

    private void FixedUpdate()
    {
        if (rigidbody != null && BulletData != null)
            rigidbody.MovePosition(transform.position + BulletData.Speed * transform.right * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

    }

    private void HitObstacle()
    {

    }
}