using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [Header("Scoring")]
    public int currentScore = 0; //The current score in this round.

    [Header("Audio Components")]
    public AudioSource bgMusic; // background music and FX

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        Application.targetFrameRate = 60;

        AudioSource[] allAudio = GetComponents<AudioSource>();
        bgMusic = allAudio[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
