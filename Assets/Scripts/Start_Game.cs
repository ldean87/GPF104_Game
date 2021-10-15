using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Start_Game : MonoBehaviour
{

    public void PlayGame() // Sets the difficulty setting to 'EASY' and begins a new game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame() // Sets the difficulty setting to 'EASY' and begins a new game
    {
        Application.Quit();
    }

}
