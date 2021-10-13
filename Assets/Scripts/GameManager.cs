using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [Header("Scoring")]
    public int currentScore = 0; //The current score in this round.
    public float movementSpeed = 0.0f;

    private int previousScore;

    [Header("Audio Components")]
    public AudioSource bgMusic; // background music and FX

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        previousScore = currentScore;
        movementSpeed = 12.0f;
        Application.targetFrameRate = 60;

        AudioSource[] allAudio = GetComponents<AudioSource>();
        bgMusic = allAudio[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore != previousScore)
        {
            if (currentScore == previousScore + 10)
            {
                previousScore = currentScore;
            }
            else if (currentScore > previousScore + 10)
            {
                currentScore = previousScore + 10;
            }
        }
        
    }
}
