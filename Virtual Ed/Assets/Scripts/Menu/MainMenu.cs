using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level_1");
        //time scale reset on scene
    }

    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void ReplayLevel()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
