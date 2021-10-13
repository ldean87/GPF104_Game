using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpin : MonoBehaviour
{
    private GameManager myGameManager; //A reference to the GameManager in the scene.
    public Player Player; // A reference to the Playable Character in the scene.
    public Rigidbody2D rockBody;


    // Start is called before the first frame update
    void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();
        Player = FindObjectOfType<Player>();
        rockBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 90 * Time.deltaTime));
        rockBody.AddForce(new Vector3 (0.0f, Random.Range(-10.0f, 10.0f), 0.0f));
        //rockBody.velocity = new Vector3(0.0f, Random.Range(-7.0f, 7.0f), 0.0f);


        // Handling the Ray Cast Collision detection for the UP direction
        RaycastHit2D upHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.up, 1.0f);

        // Handling the Ray Cast Collision detection for the DOWN direction
        RaycastHit2D downHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.up, 1.0f);

        // Handling the Ray Cast Collision detection for the LEFT direction
        RaycastHit2D leftHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, 1.0f);

        // Handling the Ray Cast Collision detection for the RIGHT direction
        RaycastHit2D rightHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.left, 1.0f);

        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(1.0f, 0.0f, 0), Color.green);
        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(-1.0f, 0.0f, 0), Color.red);
        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(0.0f, 1.0f, 0), Color.yellow);
        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(0.0f, -1.0f, 0), Color.cyan);



        if (upHit.collider != null || downHit.collider != null || leftHit.collider != null || rightHit.collider != null)
        {
            Destroy(gameObject);
        }

    }


}
