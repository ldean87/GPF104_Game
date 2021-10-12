using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Referencing other scripts in the scene
    private GameManager myGameManager; //A reference to the GameManager in the scene.
    private Player Player; // A reference to the Playable Character in the scene.


    [Header("UI Components & Variables")]
    public Text distance; // A text holder for the current score
    public Text score; // A text holder for the current score
    public Transform target;
    private int dist;
    private int tokenScore;
    //public Text lives; // A text holder for the current amount of lives


    // Start is called before the first frame update
    void Start()
    {
        // Initializing other used scripts in the scene
        myGameManager = FindObjectOfType<GameManager>();
        Player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = (int)target.position.x / 5;
        tokenScore = myGameManager.currentScore;
        distance.text = dist.ToString() + "m";
        score.text = tokenScore.ToString() + " T";
    }
}
