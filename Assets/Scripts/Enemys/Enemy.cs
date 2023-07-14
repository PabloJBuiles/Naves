using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] int score = 8;
    int maxHealth = 0;
    Player player;
    [SerializeField] GameObject enemyDeathEffect;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                if (bullet.GetOwner() == BulletType.Player)
                {
                    bullet.gameObject.SetActive(false);
                    bullet.Explodes();
                    health -= bullet.GetDamage();
                    if (health <= 0)
                    {
                        Die();
                    }
                }
            }
        }

        if (other.CompareTag("Laser"))
        {
            Die();
        }
   
    }

    public void Die()
    {
        gameObject.SetActive(false);
        player.AddPoints(score);
        GameManager.Instance.UpdateScore();
        Instantiate(enemyDeathEffect, transform.position, transform.rotation);
    }
    public void DieNoPoints()
    {
        gameObject.SetActive(false);
        GameManager.Instance.UpdateScore();
        Instantiate(enemyDeathEffect, transform.position, transform.rotation);
    }
    public void Resurrect()
    {
        maxHealth ++;
        health = maxHealth;
        gameObject.SetActive(true);
    }

    public void Heal(int healthPower)
    {
        health += healthPower;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
