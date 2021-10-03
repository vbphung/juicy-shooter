using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected WeaponRenderer weaponRenderer;
    protected float desireAngle;

    private void Awake()
    {
        weaponRenderer = GetComponentInChildren<WeaponRenderer>();
    }

    public virtual void AimPosition(Vector2 pointer)
    {
        var aimDirection = (Vector3)pointer - transform.position;
        desireAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        AdjustWeaponRendering();
        transform.rotation = Quaternion.AngleAxis(desireAngle, Vector3.forward);
    }

    protected void AdjustWeaponRendering()
    {
        if (weaponRenderer != null)
        {
            weaponRenderer.FlipSprite(desireAngle > 90 || desireAngle < -90);
            weaponRenderer.RenderBehindHead(desireAngle < 180 || desireAngle > 0);
        }
    }
}