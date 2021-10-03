using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject muzzle;
    [SerializeField] protected WeaponDataSO weaponData;
    [SerializeField] protected int ammo;
    [SerializeField] protected bool reloadCoroutine = false;
    [field: SerializeField] public UnityEvent OnShoot { get; set; }
    [field: SerializeField] public UnityEvent OnShootNoAmmo { get; set; }

    public bool FullAmmo { get => Ammo >= weaponData.AmmoCapacity; }
    public int Ammo { get => ammo; set => ammo = Mathf.Clamp(value, 0, weaponData.AmmoCapacity); }

    protected bool isShooting = true;

    private void Start()
    {
        Ammo = weaponData.AmmoCapacity;
    }

    private void Update()
    {
        UseWeapon();
    }

    public void TryShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    public void Reload(int reload)
    {
        Ammo += reload;
    }

    private void UseWeapon()
    {
        if (isShooting && !reloadCoroutine)
        {
            if (Ammo > 0)
            {
                --Ammo;
                OnShoot?.Invoke();
                for (int i = 0; i < weaponData.BulletCountToSpawn; ++i)
                    ShootBullet();
            }
            else
            {
                isShooting = false;
                OnShootNoAmmo?.Invoke();
                return;
            }

            FinishShooting();
        }
    }

    private void ShootBullet()
    {
        Debug.Log("fyinggggg");
    }

    private void FinishShooting()
    {
        StartCoroutine(DelayToNextShoot());
        isShooting = weaponData.AutomaticFire;
    }

    protected IEnumerator DelayToNextShoot()
    {
        reloadCoroutine = true;
        yield return new WaitForSeconds(weaponData.WeaponDelay);
        reloadCoroutine = false;
    }
}