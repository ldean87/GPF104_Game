using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points_Move : MonoBehaviour
{
    private GameManager myGameManager; //A reference to the GameManager in the scene.
    public Rigidbody2D pointBody;


    // Start is called before the first frame update
    void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();
        pointBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.right * (myGameManager.movementSpeed * 0.75f) * Time.deltaTime;
    }
}
