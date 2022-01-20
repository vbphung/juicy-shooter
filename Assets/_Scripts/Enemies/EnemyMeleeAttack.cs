using UnityEngine;

public class EnemyMeleeAttack : EnemyAttack
{
    public override void Attack(float damage)
    {
        if (!waitBeforeNextAttack)
        {
            var hittable = GetTarget().GetComponent<IHittable>();
            hittable?.GetHit(damage, null);
            StartCoroutine(WaitBeforeAttack());
        }
    }
}