using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    private GameManager myGameManager; //A reference to the GameManager in the scene.
    public Player Player; // A reference to the Playable Character in the scene.
    public GameObject Token; //This object is used to hold clones of the prefab called "Token"
    private float tokenSpawnTimer = 0.0f; // This variable is used to store a spawning timer for the "Token" Prefab
    private float tokenSpawnTimerRandomizer = 0.0f; // This variable is used to Randomize the spawning times for the "BlueCar" Prefab



    // Start is called before the first frame update
    void Start()
    {
        // Initiazliing the game manager
        myGameManager = FindObjectOfType<GameManager>();
        Player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        tokenSpawnTimer = tokenSpawnTimer += Time.deltaTime * 1.0f;

        if (tokenSpawnTimer >= tokenSpawnTimerRandomizer) // Used to instantiate a clone of the "BlueCar" Prefab
        {
            Destroy(Instantiate(Token, new Vector2(Player.transform.position.x + 30.0f, Random.Range(-7.0f, 3.0f)), Quaternion.identity), 5.0f);
            Token.name = "Token";
            Token.GetComponent<SpriteRenderer>().sortingOrder = 8;
            tokenSpawnTimer = 0.0f;
            tokenSpawnTimerRandomizer = Random.Range(1.5f, 3.0f);
        }
    }

}
