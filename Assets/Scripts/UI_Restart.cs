using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UI_Restart : MonoBehaviour
{
    // Referencing other scripts in the scene
    public void BacktoMainMenu() // Sets the difficulty setting to 'EASY' and begins a new game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
