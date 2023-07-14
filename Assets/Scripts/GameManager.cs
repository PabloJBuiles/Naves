using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }
    Player player;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    
    
    
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
            Destroy(gameObject); // Destroys duplicate GameManager instances
        }
        
        DontDestroyOnLoad(gameObject); // Keeps the GameManager persistent across scene changes
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + player.GetPoints().ToString();    
    }

    public void UpdateLives()
    {
        livesText.text = "Lives: " + player.GetLives().ToString();
    }
}
