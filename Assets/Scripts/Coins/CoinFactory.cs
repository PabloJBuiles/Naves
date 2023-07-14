using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFactory : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] int numberOfCoins = 10;
    [SerializeField] float spawnTime = 1f;
    [SerializeField] int spawnRange = 10;
    [SerializeField] Transform spawnPoint;
    private List<GameObject> coins = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnCoin), 0f, spawnTime);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCoin()
    {
        Debug.Log("SpawnEnemy");
        int randomX = Random.Range(-spawnRange, spawnRange);
        int randomy = Random.Range(-spawnRange, spawnRange);
        if (coins.Count < numberOfCoins)
        {
            GameObject coin = Instantiate(coinPrefab, new Vector3(randomX,randomy,spawnPoint.position.z), spawnPoint.rotation);
            coins.Add(coin);
            Debug.Log("SpawnNewCoin");
        }
        else
        {
            for (int i = 0; i < coins.Count; i++)
            {
                if (!coins[i].activeInHierarchy)
                {
                    coins[i].transform.position = new Vector3(randomX,randomy,spawnPoint.position.z);
                    coins[i].transform.rotation = spawnPoint.rotation;
                    coins[i].SetActive(true);
                    Debug.Log("ResurrectCoin");
                    break;
                }
            }
        }
        
    }
}
