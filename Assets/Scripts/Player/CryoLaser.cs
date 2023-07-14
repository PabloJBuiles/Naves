using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryoLaser : MonoBehaviour
{
    [SerializeField]float cd = 30f;
   [SerializeField] float cdTimer = 0f;
    [SerializeField] GameObject cryoLaser;

    private void Update()
    {
    
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        cdTimer -= Time.deltaTime;
        if (cdTimer <= 0f)
        {
            if (Input.GetButtonDown("Jump"))
            {
                cdTimer = cd;
                cryoLaser.SetActive(true);
                Invoke(nameof(DisableCryoLaser), 3f);
            }
        }
    }
    public void DisableCryoLaser()
    {
        cryoLaser.SetActive(false);
    }
}
