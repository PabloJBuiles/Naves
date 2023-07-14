using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] float spawnTime = 1f;
    [SerializeField] int spawnRange = 10;
    [SerializeField] Transform spawnPoint;
    [SerializeField] int maxEnemies = 10;
    private List<GameObject> enemies = new List<GameObject>();

        // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        Debug.Log("SpawnEnemy");
        int randomIndex = Random.Range(0, enemyPrefabs.Count);
        int randomX = Random.Range(-spawnRange, spawnRange);
        if (enemies.Count < maxEnemies)
        {
            GameObject enemy = Instantiate(enemyPrefabs[randomIndex], new Vector3(randomX,spawnPoint.position.y,spawnPoint.position.z), spawnPoint.rotation);
            enemies.Add(enemy);
            Debug.Log("SpawnNewEnemy");
        }
        else
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (!enemies[i].activeInHierarchy)
                {
                    enemies[i].transform.position = spawnPoint.position;
                    enemies[i].transform.rotation = spawnPoint.rotation;
                    enemies[i].GetComponent<Enemy>().Resurrect();
                    enemies[i].SetActive(true);
                    Debug.Log("ResurrectEnemy");
                    break;
                }
            }
        }
    }
    public void DestroyAllEnemys()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].activeInHierarchy)
            {
                enemies[i].GetComponent<Enemy>().DieNoPoints();
            }
        }
    }
    
    public void EnemieAdd(GameObject newEnemy)
    {
        spawnTime -= 0.75f;
        enemyPrefabs.Add(newEnemy);
        maxEnemies+=25;
    }
}
