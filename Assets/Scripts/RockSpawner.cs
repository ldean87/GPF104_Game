using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public Player Player; // A reference to the Playable Character in the scene.
    public GameObject Rock; //This object is used to hold clones of the prefab called "Token"
    private float rockSpawnTimer = 0.0f; // This variable is used to store a spawning timer for the "Token" Prefab
    private float rockSpawnTimerRandomizer = 0.0f; // This variable is used to Randomize the spawning times for the "BlueCar" Prefab



    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<Player>();
        Rock.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rockSpawnTimer = rockSpawnTimer += Time.deltaTime * 1.0f;

        if (rockSpawnTimer >= rockSpawnTimerRandomizer) // Used to instantiate a clone of the "BlueCar" Prefab
        {
            Destroy(Instantiate(Rock, new Vector2(Player.transform.position.x + 30.0f, Random.Range(-7.0f, 3.0f)), Quaternion.identity), 5.0f);
            Rock.name = "Rock";
            Rock.GetComponent<SpriteRenderer>().sortingOrder = 8;
            rockSpawnTimer = 0.0f;
            rockSpawnTimerRandomizer = Random.Range(2.0f, 4.5f);
        }
    }
}
