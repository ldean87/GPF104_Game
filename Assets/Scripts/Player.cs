using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Player Component Variables")]
    public Rigidbody2D Character;
    public float movementSpeed;
    public int playerTotalLives = 5; //Players total possible lives.
    public int playerLivesRemaining; //PLayers actual lives remaining.
    public bool playerIsAlive = true; //Is the player currently alive?
    public bool playerCanMove; //Can the player currently move?
    public int maxSpeed;
    private Animator PlayerAnimation;
    private SpriteRenderer PlayerSprites;
    public bool isGrounded;
    public float jumpCoolDown;



    // Start is called before the first frame update
    void Start()
    {
        playerLivesRemaining = playerTotalLives;
        Character = GetComponent<Rigidbody2D>();
        PlayerAnimation = gameObject.GetComponent<Animator>();
        PlayerSprites = gameObject.GetComponent<SpriteRenderer>();
        PlayerAnimation.SetBool("Walk", false);
        movementSpeed = 10.0f;
        maxSpeed = 10;
        isGrounded = true;
        jumpCoolDown = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        jumpCoolDown += Time.deltaTime;
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




        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.position += Vector3.up * movementSpeed * Time.deltaTime;
        //    PlayerSprites.flipX = false;
        //    PlayerAnimation.SetBool("Walk", true);
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.position += -Vector3.up * movementSpeed * Time.deltaTime;
        //    PlayerSprites.flipX = false;
        //    PlayerAnimation.SetBool("Walk", true);
        //}


        if (Input.GetKey(KeyCode.Space))
        {
            Character.AddForce(transform.up * 30.0f);
            PlayerAnimation.SetTrigger("Fly");
            jumpCoolDown = 0.0f;
        }


        //if (isGrounded != true)
        //{
        //    if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        //    {
        //        PlayerAnimation.SetBool("Walk", true);
        //    }
        //}


        //if (jumpCoolDown >= 1.5f) // 1.5 seconds for jump cooldown
        //{
        //    if (isGrounded != true && Input.GetKey(KeyCode.RightArrow))
        //    {
        //        if (Input.GetKeyDown(KeyCode.Space))
        //        {
        //            Character.AddForce(transform.up * 50.0f);
        //            PlayerAnimation.SetTrigger("Fly"); 
        //            jumpCoolDown = 0.0f;
        //        }
        //    }
        //    if (isGrounded != true && Input.GetKey(KeyCode.LeftArrow))
        //    {
        //        if (Input.GetKeyDown(KeyCode.Space))
        //        {
        //            Character.AddForce(-transform.right * 450.0f);
        //            Character.AddForce(transform.up * 250.0f);
        //            PlayerAnimation.SetTrigger("Fly");
        //            jumpCoolDown = 0.0f;
        //        }
        //    }
        //}

    }

}
