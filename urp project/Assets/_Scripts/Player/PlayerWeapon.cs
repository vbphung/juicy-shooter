using UnityEngine;

public class PlayerWeapon : AgentWeapon
{
    public bool FullAmmo
    {
        get
        {
            if (weapon == null)
                weapon = GetComponentInChildren<Weapon>();

            return weapon.FullAmmo;
        }
    }

    public void ReloadAmmo(int ammo)
    {
        weapon.Ammo += ammo;
    }
}