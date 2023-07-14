using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealer : MonoBehaviour
{
    [SerializeField] int healthPower = 5;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Heal(healthPower);
            }
        }
    }
}
