using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public virtual BulletDataSO BulletData { get; set; }

    protected BulletDataSO bulletData;
}