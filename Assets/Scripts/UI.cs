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
    public Text tokens; // A text holder for the current score
    public Text score; // A text holder for the current score
    public Text endTotalScore; // A text holder for the current score
    public Transform target;
    public GameObject endScore;
    private int dist;
    private int tokenScore;
    private int totalScore;
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
        dist = (int)myGameManager.playerDistance;
        tokenScore = myGameManager.currentScore;
        totalScore = (int)myGameManager.totalScore;
        distance.text = dist.ToString() + "m";
        tokens.text = tokenScore.ToString() + " T";
        score.text = totalScore.ToString() + "";

        if (myGameManager.dragonLives <= 0)
        {
            endScore.gameObject.SetActive(true);
            endTotalScore.text = totalScore.ToString() + "";
        }
        else if (myGameManager.dragonLives > 0)
        {
            endScore.gameObject.SetActive(false);
            endTotalScore.text = totalScore.ToString() + "";
        }
    }
}
