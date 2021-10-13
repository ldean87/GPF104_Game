using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private GameManager myGameManager; //A reference to the GameManager in the scene.

    [Header("Player Component Variables")]
    public Rigidbody2D Character;
    public GameObject Tokens;
    public float movementSpeed;
    public int playerTotalLives = 5; //Players total possible lives.
    public int playerLivesRemaining; //PLayers actual lives remaining.
    public bool playerIsAlive = true; //Is the player currently alive?
    public bool playerCanMove; //Can the player currently move?
    private Animator PlayerAnimation;
    private SpriteRenderer PlayerSprites;
    public float touchCoolDown;
    public float jumpForce;

    [Header("Audio Sources")]
    public AudioSource pushSound;


    Collision collision;


    // Start is called before the first frame update
    void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();
        playerLivesRemaining = playerTotalLives;
        Character = GetComponent<Rigidbody2D>();
        PlayerAnimation = gameObject.GetComponent<Animator>();
        PlayerSprites = gameObject.GetComponent<SpriteRenderer>();
        PlayerAnimation.SetTrigger("Fly");
        movementSpeed = 16.0f;
        touchCoolDown = 0.0f;
        jumpForce = 12.0f;

        // Initialising multiple Audio Components
        AudioSource[] allAudio = GetComponents<AudioSource>();
        pushSound = allAudio[0];
    }



    // Update is called once per frame
    void FixedUpdate()
    {

        RaycastHit2D upHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.up, 0.8f);

        // Handling the Ray Cast Collision detection for the DOWN direction
        RaycastHit2D downHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.up, 1.6f);

        // Handling the Ray Cast Collision detection for the LEFT direction
        RaycastHit2D leftHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, 1.6f);

        // Handling the Ray Cast Collision detection for the RIGHT direction
        RaycastHit2D rightHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.left, 1.4f);

        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(1.4f, 0.0f, 0), Color.green);
        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(-1.6f, 0.0f, 0), Color.red);
        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(0.0f, 0.8f, 0), Color.yellow);
        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(0.0f, -1.6f, 0), Color.cyan);


        if (upHit.collider != null || downHit.collider != null || leftHit.collider != null || rightHit.collider != null)
        {

            //if (collision.gameObject.tag == "Token")
            //{
            //    Debug.Log("Collided with" + collision.gameObject.name);
            //    //StartCoroutine(Die());
            //}

        }




        transform.position += Vector3.right * myGameManager.movementSpeed * Time.deltaTime;
        touchCoolDown += 1 * Time.deltaTime;

        if (touchCoolDown >= 0.1f)
        {
            if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButton(0)) {
                Character.velocity = new Vector2(0, jumpForce);

                if (pushSound.isPlaying) {
                    // Do nothing
                }
                else {
                    pushSound.Play();
                }

                touchCoolDown = 0.0f;
            }
        }
    }
}

