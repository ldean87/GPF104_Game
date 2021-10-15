using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [Header("Scoring")]
    public int currentScore = 0; //The current score in this round.
    public float totalScore;
    public int tokensCollected = 0;
    public float movementSpeed = 0.0f;
    public int dragonLives;
    public float playerDistance;
    private int previousScore;

    [Header("Audio Components")]
    public AudioSource bgMusic; // background music and FX

    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0.0f;
        currentScore = 0;
        previousScore = currentScore;
        tokensCollected = 0;
        movementSpeed = 12.0f;
        dragonLives = 4;
        Application.targetFrameRate = 60;
        AudioSource[] allAudio = GetComponents<AudioSource>();
        bgMusic = allAudio[0];

        if (bgMusic.isPlaying)
        {
            // Do nothing
        }
        else
        {
            bgMusic.Play();
        }
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

        totalScore = ((tokensCollected * 10) * playerDistance); 
    }
}
