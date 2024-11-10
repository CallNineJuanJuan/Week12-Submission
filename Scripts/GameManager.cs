using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyOne;
    public GameObject cloud;
    public GameObject coin;

    private int lives;
    public TextMeshProUGUI livesText;

    public TextMeshProUGUI scoreText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate the player at a defined spawn position
        Vector3 spawnPosition = new Vector3(0, -3f, 0);  // Example spawn position
        Instantiate(player, spawnPosition, Quaternion.identity);

        // Start enemy creation
        InvokeRepeating("CreateEnemyOne", 1f, 3f);

        // Create sky (clouds)
        CreateSky();

        //Create coins
        SpawnCoin();
        InvokeRepeating("SpawnCoin", 1f, 2f);

        // Initialize score and lives
        score = 0;
        scoreText.text = "Score: " + score;
        lives = 3;
        livesText.text = "Lives: " + lives;
    }

    // Create enemy at random x-position
    void CreateEnemyOne()
    {
        Instantiate(enemyOne, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    // Create clouds in the sky
    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    void SpawnCoin()
    {
        Instantiate(coin, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
    }

    public void EarnScore(int newScore)
    {
        score += newScore;
        scoreText.text = "Score: " + score;
    }

    public void LoseALife()
    {
        lives--;
        if (lives == 0)
        {
            Destroy(GameObject.FindWithTag("Player"));
        }
        livesText.text = "Lives: " + lives;
    }
}
