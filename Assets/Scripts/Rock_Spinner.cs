using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Spinner : MonoBehaviour
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
        rockBody.AddForce(new Vector3 (0.0f, Random.Range(-15.0f, 15.0f), 0.0f));
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine("Die");
        }
        else
        {
            //do nothing
        }
    }



    //And function itself
    IEnumerator Die()
    {
        Destroy(gameObject); //this will work after 3 seconds.
        yield return new WaitForSeconds(0.02f); //waits 0.02 seconds
    }


}
