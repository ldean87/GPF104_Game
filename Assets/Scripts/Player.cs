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
    private SpriteRenderer playerSprite;
    public float movementSpeed;
    public bool playerIsAlive = true; //Is the player currently alive?
    public bool playerCanMove;
    private Animator PlayerAnimation;
    public float touchCoolDown;
    public int jumpForce;
    public float hitCoolDown;


    [Header("Audio Sources")]
    public AudioSource pushSound;
    public AudioSource tokenCollect;
    public AudioSource rockHit;




    // Start is called before the first frame update
    void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();
        playerSprite = GetComponent<SpriteRenderer>();
        Character = GetComponent<Rigidbody2D>();
        playerCanMove = true;
        PlayerAnimation = gameObject.GetComponent<Animator>();
        PlayerAnimation.SetTrigger("Fly");
        movementSpeed = 16.0f;
        touchCoolDown = 0.0f;
        jumpForce = 0;
        hitCoolDown = 0.0f;

        // Initialising multiple Audio Components
        AudioSource[] allAudio = GetComponents<AudioSource>();
        pushSound = allAudio[0];
        tokenCollect = allAudio[1];
        rockHit = allAudio[2];
    }



    void Update()
    {
        if (myGameManager.dragonLives <= 0)
        {
            myGameManager.movementSpeed = 0.0f;
            playerCanMove = false;
        }
        if (playerCanMove == true) {
            resetJumpForce();
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerCanMove == true)
        {
            resetJumpForce();
            transform.position += Vector3.right * myGameManager.movementSpeed * Time.deltaTime;
            touchCoolDown += 1 * Time.deltaTime;
            hitCoolDown += 1 * Time.deltaTime;
            myGameManager.playerDistance = transform.position.x / 4;

            if (touchCoolDown >= 0.1f)
            {
                if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButton(0)) 
                {
                    if (jumpForce >= 0.0f && jumpForce <= 20.0f) {
                    
                        jumpForce = jumpForce + 4;
                    }
                              
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
            resetJumpForce();

            if (hitCoolDown >= 0.3f)
            {
                playerSprite.color = new Color(1, 1, 1);
            }
        }
    }





    private void resetJumpForce()
    {
        if (Input.GetKeyUp(KeyCode.Space) 
            || Input.touchCount > 0 
            && Input.GetTouch(0).phase == TouchPhase.Ended 
            || Input.GetMouseButtonUp(0))
        {
            jumpForce = 0;
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerCanMove == true)
        {
            if (collision.CompareTag("Token"))
            {
                Debug.Log("Token");
                if (tokenCollect.isPlaying)
                {
                    // Do nothing
                }
                else
                {
                    tokenCollect.Play();
                }
            }
            else if (collision.CompareTag("Rock"))
            {
                Debug.Log("Rock");
                if (rockHit.isPlaying)
                {
                    // Do nothing
                }
                else
                {
                    rockHit.Play();
                }
                Character.AddForce(-transform.right * 15.0f, ForceMode2D.Impulse);
                touchCoolDown = -0.5f;
                StartCoroutine("hitColor");
            }
        }
    }







    IEnumerator hitColor()
    {
        //play your sound
        hitCoolDown = 0.0f;
        playerSprite.color = new Color(1, 0, 0);
        switch (myGameManager.dragonLives)
        {
            case 4:
                myGameManager.dragonLives = 3;
                break;
            case 3:
                myGameManager.dragonLives = 2;
                break;
            case 2:
                myGameManager.dragonLives = 1;
                break;
            case 1:
                myGameManager.dragonLives = 0;
                break;

            default:
                break;
        }
        yield return new WaitForSeconds(3.0f); //waits 0.02 seconds
    }

}


