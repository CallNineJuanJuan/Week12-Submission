using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip collectCoin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            //The player hits me
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(1);
            AudioSource.PlayClipAtPoint(collectCoin, Camera.main.transform.position);
            Destroy(this.gameObject);
        }
    }
}