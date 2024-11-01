using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemyType1;
    public GameObject enemyType2;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemyType1", 1f, 3f);
        InvokeRepeating("CreateEnemyType2", 5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemyType1()
    {
        Instantiate(enemyType1, new Vector3(Random.Range(-9f, 9f), 9f, 0), Quaternion.identity);
    }

    void CreateEnemyType2()
    {
        Instantiate(enemyType2, new Vector3(-12f, Random.Range(-9f, 9f), 0), Quaternion.identity);
    }
}
