using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private GameManager myGameManager; //A reference to the GameManager in the scene.
    private UI UIElements; //A reference to the GameManager in the scene.

    [Header("Player Component Variables")]
    public Rigidbody2D Character;
    public float movementSpeed;
    public int playerTotalLives = 5; //Players total possible lives.
    public int playerLivesRemaining; //PLayers actual lives remaining.
    public bool playerIsAlive = true; //Is the player currently alive?
    public bool playerCanMove; //Can the player currently move?
    private Animator PlayerAnimation;
    private SpriteRenderer PlayerSprites;
    private float reso;





    // Start is called before the first frame update
    void Start()
    {
        UIElements = FindObjectOfType<UI>();
        myGameManager = FindObjectOfType<GameManager>();
        playerLivesRemaining = playerTotalLives;
        Character = GetComponent<Rigidbody2D>();
        PlayerAnimation = gameObject.GetComponent<Animator>();
        PlayerSprites = gameObject.GetComponent<SpriteRenderer>();
        PlayerAnimation.SetBool("Walk", false);
        movementSpeed = 10.0f;
        reso = (float)Screen.height;
    }



    // Update is called once per frame
    void Update()
    {
        PlayerAnimation.SetTrigger("Fly");
        transform.position += Vector3.right * movementSpeed * Time.deltaTime;

        // Handling the Ray Cast Collision detection for the UP direction
        RaycastHit2D upHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.up, 0.5f);
        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(0.0f, 0.5f, 0), Color.yellow);


        // Handling the Ray Cast Collision detection for the DOWN direction
        RaycastHit2D downHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.up, 1.2f);
        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(0.0f, -1.2f, 0), Color.cyan);


        // Handling the Ray Cast Collision detection for the LEFT direction
        RaycastHit2D leftHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, 1.2f);
        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(-1.2f, 0.0f, 0), Color.red);


        // Handling the Ray Cast Collision detection for the RIGHT direction
        RaycastHit2D rightHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.left, 1.2f);
        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(1.2f, 0.0f, 0), Color.green);



        if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButton(0))
        {
            if (reso <= 720)
                Character.AddForce(transform.up * reso / 30);

            if (reso > 720 && reso <= 1080)
                Character.AddForce(transform.up * reso / 37.5f);

            if (reso > 1080 && reso <= 1440)
                Character.AddForce(transform.up * reso / 45);

            if (reso > 1440 && reso <= 2160)
                Character.AddForce(transform.up * reso / 60);
        }

    }

}
