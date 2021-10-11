using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tokens : MonoBehaviour
{
    private GameManager myGameManager; //A reference to the GameManager in the scene.
    //public Player Player; // A reference to the Playable Character in the scene.
    public GameObject Player;
    public GameObject Token; //This object is used to hold clones of the prefab called "Token"
    private float tokenSpawnTimer = 0.0f; // This variable is used to store a spawning timer for the "Token" Prefab
    private float tokenSpawnTimerRandomizer = 0.0f; // This variable is used to Randomize the spawning times for the "BlueCar" Prefab


    private void Awake()
    {
        gameObject.AddComponent<BoxCollider2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        // Initiazliing the game manager
        myGameManager = FindObjectOfType<GameManager>();
        //Player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        //// Handling the Ray Cast Collision detection for the UP direction
        //RaycastHit2D upHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.up, 0.5f);

        //// Handling the Ray Cast Collision detection for the DOWN direction
        //RaycastHit2D downHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.up, 0.5f);

        //// Handling the Ray Cast Collision detection for the LEFT direction
        //RaycastHit2D leftHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, 0.5f);

        //// Handling the Ray Cast Collision detection for the RIGHT direction
        //RaycastHit2D rightHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.left, 0.5f);

        //Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(0.5f, 0.0f, 0), Color.green);
        //Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(-0.5f, 0.0f, 0), Color.red);
        //Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(0.0f, 0.5f, 0), Color.yellow);
        //Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(0.0f, -0.5f, 0), Color.cyan);


       // OnTriggerStay2D();


        tokenSpawnTimer = tokenSpawnTimer += Time.deltaTime * 1.0f;

        if (tokenSpawnTimer >= tokenSpawnTimerRandomizer) // Used to instantiate a clone of the "BlueCar" Prefab
        {
            Destroy(Instantiate(Token, new Vector2(Player.transform.position.x + 30.0f, Random.Range(-7.0f, 0.0f)), Quaternion.identity), 5.0f);
            Token.name = "New Token";
            Token.GetComponent<SpriteRenderer>().sortingOrder = 8;
            tokenSpawnTimer = 0.0f;
            tokenSpawnTimerRandomizer = Random.Range(2.5f, 5.0f);
        }
    }




    //Overlapping a collider 2D
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Do something
    }
}
