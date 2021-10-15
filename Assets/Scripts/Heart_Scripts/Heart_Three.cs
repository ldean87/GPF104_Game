using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Three : MonoBehaviour
{
    private GameManager myGameManager; //A reference to the GameManager in the scene.

    void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myGameManager.dragonLives < 3)
        {
            Destroy(gameObject);
        }
    }
}
