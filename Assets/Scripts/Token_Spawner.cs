using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token_Spawner : MonoBehaviour
{
    private GameManager myGameManager; //A reference to the GameManager in the scene.
    public Player Player; // A reference to the Playable Character in the scene.
    public GameObject Token; //This object is used to hold clones of the prefab called "Token"
    private float tokenSpawnTimer = 0.0f; // This variable is used to store a spawning timer for the "Token" Prefab
    private float tokenSpawnTimerRandomizer = 0.0f; // This variable is used to Randomize the spawning times for the "BlueCar" Prefab
    private float minRange;
    private float maxRange;



    // Start is called before the first frame update
    void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();
        Player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        tokenSpawnTimer = tokenSpawnTimer += Time.deltaTime * 1.0f;


        if (myGameManager.playerDistance >= 0 && myGameManager.playerDistance < 150)
        {
            minRange = 1.0f;
            maxRange = 3.0f;
        }
        else if (myGameManager.playerDistance >= 150 && myGameManager.playerDistance < 300)
        {
            minRange = 0.75f;
            maxRange = 2.75f;
        }
        else if (myGameManager.playerDistance >= 300 && myGameManager.playerDistance < 500)
        {
            minRange = 0.5f;
            maxRange = 2.5f;
        }
        else if (myGameManager.playerDistance >= 500)
        {
            minRange = 0.25f;
            maxRange = 2.0f;
        }

        if (tokenSpawnTimer >= tokenSpawnTimerRandomizer) // Used to instantiate a clone of the "BlueCar" Prefab
        {
            if (myGameManager.dragonLives > 0)
            {
                Destroy(Instantiate(Token, new Vector2(Player.transform.position.x + 30.0f, Random.Range(-7.0f, 3.0f)), Quaternion.identity), 5.0f);
                Token.name = "Token";
                Token.tag = "Token";
                Token.GetComponent<SpriteRenderer>().sortingOrder = 8;
                tokenSpawnTimer = 0.0f;
                tokenSpawnTimerRandomizer = Random.Range(minRange, maxRange);
            }
        }
    }

}
