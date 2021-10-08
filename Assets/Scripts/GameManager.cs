using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [Header("Scoring")]
    public int currentScore = 0; //The current score in this round.

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
