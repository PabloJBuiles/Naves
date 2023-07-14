using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Player,
    Enemy
}
public class Bullet : MonoBehaviour
{
    BulletType bulletType;
    float damage;
    [SerializeField, Range(0.01f, 50f)] float speed = 0.75f;
    Rigidbody2D rb;

    [SerializeField] private GameObject bulletHitEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(speed);
    }
    public void Movement(float speed)
    {
        Vector2 movement = transform.up.normalized;
        rb.velocity = movement * speed;
    }
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
    
    public void SetOwner(BulletType bulletType)
    {
        this.bulletType = bulletType;
    }
    public void DisableBullet(float range)
    {
        StartCoroutine(DisableBulletAfterTime(range));
    }
    
    IEnumerator DisableBulletAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    public BulletType GetOwner()
    {
        return bulletType;
    }
    
    public void Explodes()
    {
        GameObject bulletHit = Instantiate(bulletHitEffect, transform.position, transform.rotation);
        Destroy(bulletHit, 1.5f);
    }
}
