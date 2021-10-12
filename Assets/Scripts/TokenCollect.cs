using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenCollect : MonoBehaviour
{
    private GameManager myGameManager; //A reference to the GameManager in the scene.


    [Header("Audio Sources")]
    public AudioSource tokenCollectSound;


    private void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();

        // Initialising multiple Audio Components
        AudioSource[] allAudio = GetComponents<AudioSource>();
        tokenCollectSound = allAudio[0];
    }
    // Update is called once per frame
    void Update()
    {
        collisionDetection();
    }


    void collisionDetection()
    {
        // Handling the Ray Cast Collision detection for the UP direction
        RaycastHit2D upHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.up, 0.5f);

        // Handling the Ray Cast Collision detection for the DOWN direction
        RaycastHit2D downHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.up, 0.5f);

        // Handling the Ray Cast Collision detection for the LEFT direction
        RaycastHit2D leftHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, 0.5f);

        // Handling the Ray Cast Collision detection for the RIGHT direction
        RaycastHit2D rightHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.left, 0.5f);

        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(0.5f, 0.0f, 0), Color.green);
        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(-0.5f, 0.0f, 0), Color.red);
        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(0.0f, 0.5f, 0), Color.yellow);
        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), transform.position + new Vector3(0.0f, -0.5f, 0), Color.cyan);



        if (upHit.collider != null || downHit.collider != null || leftHit.collider != null || rightHit.collider != null)
        {
            if (tokenCollectSound.isPlaying) {
                // Do nothing
            }
            else {
                playTheSound();
            }
            StartCoroutine(Die());
        }

    }

    //And function itself
    IEnumerator Die()
    {
        //play your sound
        yield return new WaitForSeconds(0.2f); //waits 0.2 seconds
        Destroy(gameObject); //this will work after 3 seconds.
        myGameManager.currentScore = myGameManager.currentScore + 10;
    }


    void playTheSound()
    {
        tokenCollectSound.Play();
    }
}
