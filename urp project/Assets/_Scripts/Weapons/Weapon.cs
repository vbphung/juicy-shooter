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

    protected bool isShooting = false;

    private void Start()
    {
        Ammo = weaponData.AmmoCapacity;
    }

    private void Update()
    {
        UseWeapon();
    }

    #region Trigger
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
    #endregion

    #region UseWeapon
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
        SpawnBullet(muzzle.transform.position, CalculateAngle(muzzle));
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

    private Quaternion CalculateAngle(GameObject calculatedObject)
    {
        float spread = UnityEngine.Random.Range(-weaponData.SpreadAngle, weaponData.SpreadAngle);
        Quaternion spreadRotation = Quaternion.Euler(new Vector3(0, 0, spread));
        return calculatedObject.transform.rotation * spreadRotation;
    }

    private void SpawnBullet(Vector3 position, Quaternion rotation)
    {
        var bullet = Instantiate(weaponData.BulletData.Prefab, position, rotation);
        bullet.GetComponent<Bullet>().BulletData = weaponData.BulletData;
    }
    #endregion
}