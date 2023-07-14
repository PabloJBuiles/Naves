using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : PlayerWeapon
{
    // Start is called before the first frame update

    protected override void CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullets.Add(bullet);
        GameObject bulletSpawn = Instantiate(bulletSpawnEffect, firePoint.position, firePoint.rotation);
        Destroy(bulletSpawn, 1f);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetDamage(damage);
        bulletScript.SetOwner(BulletType.Enemy);
        bulletScript.DisableBullet(range);
    }
}
