using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private GameManager myGameManager; //A reference to the GameManager in the scene.
    private UI UIElements; //A reference to the GameManager in the scene.

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





    // Start is called before the first frame update
    void Start()
    {
        UIElements = FindObjectOfType<UI>();
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
        transform.position += Vector3.right * movementSpeed * Time.deltaTime;
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

