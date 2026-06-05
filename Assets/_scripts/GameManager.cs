using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI coinsText;   
    public TextMeshProUGUI EnemyText;
    public int level_coins = 0;

    public int level_index = 0;

    private int health;
    private int coins;

    private int enemies;
    public void changehealth(int amount)
    {
        health += amount;
        healthText.text = "Health: " + health;
        if (health <= 0)
        {
            RestartGame();
        }
        
    }
    public void changecoins(int amount)
    {
        coins += amount;
        coinsText.text = "Coins: " + coins;
            if (coins >= level_coins)
            {
                NextLevel();
            }
    }

    public void changeenemies(int amount)
    {
        enemies += amount;  
        EnemyText.text = "Enemies: " + amount;
    }

  
    void Start()
    {
        print(SceneManager.sceneCountInBuildSettings);
        coinsText.text = "Coins: " + coins;
        healthText.text = "Health: " + health;
        EnemyText.text = "Enemies: " + enemies;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void NextLevel()
    {
        level_index += 1;
        //if (level_index >=  SceneManager.sceneCountInBuildSettings)
        //{
        //    level_index = 0;
        //}
        //print(SceneManager.sceneCountInBuildSettings); 
        SceneManager.LoadScene(level_index);
    }
}
