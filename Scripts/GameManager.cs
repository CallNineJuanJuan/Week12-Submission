using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //--------Game Objects-------
    public GameObject player;
    public GameObject enemyOne;
    public GameObject enemyTwo;
    public GameObject cloud;
    public GameObject coin;
    public GameObject powerup;
    public GameObject explosion;
    //----------------------------

    //--------Audio Clips-----------
    public AudioClip powerUp;
    public AudioClip powerDown;
    //------------------------------

    //--------Int---------
    public int cloudSpeed;
    //----------------------------------

    //---------Booleans---------
    private bool isPlayerAlive;
    public bool hasShield;
    //--------------------------

    //-----------UI Elements------------
    //Powerup
    public TextMeshProUGUI powerupText;
    //Score
    private int score;
    public TextMeshProUGUI scoreText;
    //Lives
    private int lives;
    public TextMeshProUGUI livesText;
    //Game Over
    public TextMeshProUGUI gameOverText;
    //Restart
    public TextMeshProUGUI restartText;
    //----------------------------------



    // Start is called before the first frame update
    void Start()
    {
        //Instantiate the player
        Instantiate(player, transform.position, Quaternion.identity);

        //Create enemies
        InvokeRepeating("CreateEnemyOne", 1f, 3f);
        InvokeRepeating("CreateEnemyTwo", 10f, 0.5f);

        //Spawn Powerups
        StartCoroutine(CreatePowerup());

        //Create clouds
        CreateSky();
        cloudSpeed = 1;

        //Create coins
        SpawnCoin();
        InvokeRepeating("SpawnCoin", 1f, 2f);

        //Initialize score
        score = 0;
        scoreText.text = "Score: " + score;

        //Initialize lives
        isPlayerAlive = true;
        lives = 3;
        livesText.text = "Lives: " + lives;
        hasShield = false;
    }

    // Update is called once per frame
    void Update()
    {
        Restart();
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOne, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwo, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    IEnumerator CreatePowerup()
    {
        Instantiate(powerup, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(3f, 6f));
        StartCoroutine(CreatePowerup());
    }

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
        score = score + newScore;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isPlayerAlive = false;
        CancelInvoke();
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        cloudSpeed = 0;
        StopAllCoroutines();
    }

    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R) && isPlayerAlive == false)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void UpdatePowerupText(string whichPowerup)
    {
        powerupText.text = whichPowerup;
    }

    public void PlayPowerUp()
    {
        AudioSource.PlayClipAtPoint(powerUp, Camera.main.transform.position);
    }

    public void PlayPowerDown()
    {
        AudioSource.PlayClipAtPoint(powerDown, Camera.main.transform.position);
    }
    public void LoseALife()
    {
        if (hasShield == false)
        {
            lives--;
            livesText.text = "Lives: " + lives;

        }
        else if (hasShield == true)
        {
            //lose the shield
            //no longer have a shield
        }

        if (lives == 0)
        {
            GameOver();
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(GameObject.FindWithTag("Player"));
        }

    }
}