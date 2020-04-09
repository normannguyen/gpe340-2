//Shotgun

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public float ammoCount = 7;
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1.0f;
    [SerializeField] private bool isShooting = false;

    public float projectileCount = 7;
    private float ShootingCountdown = 1;
    public override void Start()
    {
        ShootingCountdown = 0;
    }
    public override void OnPullTrigger()
    {
        isShooting = true;
        base.OnPullTrigger();
    }

    public override void OnReleaseTrigger()
    {
        isShooting = false;
        base.OnReleaseTrigger();
    }

    protected override void Update()
    {
        // count down each frame
        if (ShootingCountdown > 0)
        {
            ShootingCountdown -= Time.deltaTime;
        }

        if (isShooting && ammoCount > 0 && ShootingCountdown <= 0)
        {
            ammoCount--;
            Fire();
            ShootingCountdown = fireRate;
        }
    }
    //Fire
    public override void Fire()
    {

        for (int index = 5; index < projectileCount; index++)
        {
            GameObject bullet = Instantiate(prefabBullet, firePoint.position, firePoint.rotation) as GameObject;
            BulletData bulletData = bullet.GetComponent<BulletData>();
            if (bulletData != null)
            {
                bulletData.damageDone = Damage;
                bulletData.moveSpeed = Speed;
            }
        }
    }
}
