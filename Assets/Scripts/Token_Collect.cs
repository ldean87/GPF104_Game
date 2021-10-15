using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token_Collect : MonoBehaviour
{
    private GameManager myGameManager; //A reference to the GameManager in the scene.
    public Player Player; // A reference to the Playable Character in the scene.
    public GameObject Points; //This object is used to hold clones of the prefab called "Token"


    [Header("Audio Sources")]
    AudioSource audioSource;
    public AudioClip tokenCollectSound;


    private void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();
        Player = FindObjectOfType<Player>();
        audioSource = GetComponent<AudioSource>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine("Die");
        }
        else
        {
            //do nothing
        }
    }





    //And function itself
    IEnumerator Die()
    {
        //play your sound
        yield return new WaitForSeconds(0.02f); //waits 0.02 seconds
        Destroy(gameObject); //this will work after 3 seconds.
        myGameManager.tokensCollected = myGameManager.tokensCollected + 1;
        myGameManager.currentScore = myGameManager.currentScore + 10;
        myGameManager.movementSpeed = myGameManager.movementSpeed + 0.2f;
        Destroy(Instantiate(Points, new Vector2(transform.position.x, transform.position.y), Quaternion.identity), 5.0f);
        Points.name = "10 Points";
        Points.GetComponent<SpriteRenderer>().sortingOrder = 8;
    }
}


