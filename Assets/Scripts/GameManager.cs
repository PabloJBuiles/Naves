using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject panelUpgrade;
    [SerializeField] List<GameObject> enemies;
    [SerializeField] List<GameObject> enemiesFull;
    [SerializeField] List<string> enemiesDescription;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] List<GameObject> upgrates;
    
    // Singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }
    Player player;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    
    EnemyFactory enemyFactory;
    
    public bool isGameOver = false;
    
    // Awake is called before Start and ensures the Singleton instance is created
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
        
       // DontDestroyOnLoad(gameObject); 
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        enemyFactory = FindObjectOfType<EnemyFactory>();
    }

    void Update()
    {
        
    }
    public void AddUpgrade()
    {
        int random = UnityEngine.Random.Range(0, upgrates.Count);
        upgrates[random].SetActive(true);
        upgrates.RemoveAt(random);
        
    }
    public void AddRandomEnemies()
    {
        if (enemies.Count > 0)
        {
            int random = UnityEngine.Random.Range(0, enemies.Count);
            descriptionText.text = enemiesDescription[random];

            GameObject selectedEnemy = enemies[random];
            enemies.RemoveAt(random);
            enemiesDescription.RemoveAt(random);

            enemyFactory.EnemieAdd(selectedEnemy);
            enemyFactory.DestroyAllEnemys();
        }
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + player.GetPoints().ToString();    
    }

    public void UpdateLives()
    {
        livesText.text = "Lives: " + player.GetLives().ToString();
    }

    public void Upgrade()
    { 
        
        AddUpgrade();
        AddRandomEnemies();
      panelUpgrade.SetActive(true);
      Time.timeScale = 0;
    }
    
    public void Continue()
    {
        panelUpgrade.SetActive(false);
        Time.timeScale = 1;
    }
}
