using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandGun : Weapon
{
    //Ammo Count
    public float ammoCount = 15;
    //Bullet Prefab
    [SerializeField] private GameObject prefabBullet;
    //Fire Point for the bullet to spawn
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1.0f;
    //Boolean
    [SerializeField] private bool isShooting = false;
    //Countdown
    private float ShootingCountdown = 2;
    public override void Start()
    {
        ShootingCountdown = 0;
    }
    //OnPullTrigger
    public override void OnPullTrigger()
    {
        isShooting = true;
        base.OnPullTrigger();
    }
    //OnReleaseTrigger
    public override void OnReleaseTrigger()
    {
        isShooting = false;
        base.OnReleaseTrigger();
    }
    //Override Update
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
        GameObject bullet = Instantiate(prefabBullet, firePoint.position, firePoint.rotation) as GameObject;
        BulletData bulletData = bullet.GetComponent<BulletData>();
        if (bulletData != null)
        {
            bulletData.damageDone = Damage;
            bulletData.moveSpeed = Speed;
        }
    }
}
