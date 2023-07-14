using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int points = 5;
    //[SerializeField] AudioClip coinPickupSFX;
    [SerializeField] GameObject coinVFX;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            other.GetComponent<Player>().AddPoints(points);
            GameManager.Instance.UpdateScore();
            Instantiate(coinVFX, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }

        if (other.CompareTag("Finish"))
        {
            gameObject.SetActive(false);
        }
    }
}
