using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField,Range(0.01f,2f)] float fireRate = 0.5f;
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletSpawnEffect;
    [SerializeField] GameObject bulletHitEffect;
    [SerializeField, Range(1,50)] int maxBulletsPool = 10;
    
    private List<GameObject> bullets = new List<GameObject>();

    private float nextFire = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nextFire -= Time.deltaTime;
        if (nextFire <= 0f)
        {
            Shoot();
            nextFire = fireRate;
        }
    }

    public void Shoot()
    {
        if(bullets.Count < maxBulletsPool)
            CreateBullet();
        else
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    bullets[i].transform.position = firePoint.position;
                    bullets[i].transform.rotation = firePoint.rotation;
                    bullets[i].SetActive(true);
                    bullets[i].GetComponent<Bullet>().DisableBullet(range);
                    GameObject bulletSpawn = Instantiate(bulletSpawnEffect, firePoint.position, firePoint.rotation);
                    Destroy(bulletSpawn, 1f);
                    break;
                }
            }
        }
    }

    private void CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullets.Add(bullet);
        GameObject bulletSpawn = Instantiate(bulletSpawnEffect, firePoint.position, firePoint.rotation);
        Destroy(bulletSpawn, 1f);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetDamage(damage);
        bulletScript.SetOwner(BulletType.Player);
        bulletScript.DisableBullet(range);
    }
}
