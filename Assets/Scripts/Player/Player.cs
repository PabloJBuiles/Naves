using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    Color semiTransparent = new Color(1, 1, 1, 0.5f);
    SpriteRenderer spriteRenderer;
    [SerializeField] int points = 0;
    [SerializeField] int lives = 3;
    [SerializeField] int maxLives = 3;
    
    [SerializeField] GameObject playerDeathEffect;
    [SerializeField] GameObject playerDeathEffectDefinitive;
    [SerializeField] GameObject loseEffect;
    [SerializeField] GameObject hitEffect;
    
    bool isInvincible = false;

    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void ExtraLife()
    {
        maxLives = 5;
        lives = maxLives;
        GameManager.Instance.UpdateLives();
    }
    
    public int GetPoints()
    {
        return points;
    }
    
    int pointsToLives = 0;
    int pointsToUpgrate = 0;
    public void AddPoints(int points)
    {
        pointsToUpgrate += points;
        if (pointsToUpgrate >= 75)
        {
            pointsToUpgrate -= 75;
            GameManager.Instance.Upgrade();
        }   
  
        pointsToLives += points;
        if (pointsToLives >= 25)
        {
            pointsToLives -= 25;
            if (lives < maxLives)
            {
                lives++;
                GameManager.Instance.UpdateLives();
            }
        }   
        
        this.points += points;
    }

 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !isInvincible)
        {
            lives--;
            GameManager.Instance.UpdateLives();
            if (lives <= 0)
            {
                lives = 0;
                Die();
            }
            else
            {
                Instantiate(playerDeathEffect, transform.position, transform.rotation);
                StartCoroutine(Invicible());
            }
        }
        if (other.CompareTag("Bullet") && !isInvincible)
        {
            if (other.GetComponent<Bullet>().GetOwner() == BulletType.Enemy)
            {
                lives--;
                GameManager.Instance.UpdateLives();
                if (lives <= 0)
                {
                    lives = 0;
                    Die();
                }
                else
                {
                    Instantiate(playerDeathEffect, transform.position, transform.rotation);
                    StartCoroutine(Invicible());
                }
            }
        }
    }
    IEnumerator Invicible()
    {
        hitEffect.SetActive(true);
        spriteRenderer.color = semiTransparent;
        isInvincible = true;
        yield return new WaitForSeconds(0.5f);
        hitEffect.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        isInvincible = false;
        spriteRenderer.color = Color.white;
    }

    public void Die()
    {
        Instantiate(playerDeathEffectDefinitive, transform.position, transform.rotation);
        gameObject.SetActive(false);
        loseEffect.SetActive(true);
    }

    public void Resurrect()
    {
        lives = 1;
        points = 0;
        GameManager.Instance.UpdateLives();
        GameManager.Instance.UpdateScore();
        gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetLives()
    {
        return lives;
    }
}
