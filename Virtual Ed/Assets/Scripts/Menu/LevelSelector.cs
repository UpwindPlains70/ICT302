using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [System.Serializable]
    public class LevelButton
    {
        public Button button;
        public string sceneName;
    }

    public LevelButton[] levelButtons;

    void Start()
    {
        //on start
        //we hook the load scene function to each button's onClick event

        foreach (LevelButton levelButton in levelButtons)
        {
            levelButton.button.onClick.AddListener(() => LoadScene(levelButton)); //lambda function basically allows us to pre-fill in the function's arguments
        }
    }

    void LoadScene(LevelButton data)
    {
        SceneManager.LoadScene(data.sceneName);
    }

    public void LoadLevel1Tute()
    {
        SceneManager.LoadScene(levelButtons[0].sceneName);
    }
    public void LoadLevel2Tute()
    {
        SceneManager.LoadScene(levelButtons[1].sceneName);
    }
    public void LoadLevel3Tute()
    {
        SceneManager.LoadScene(levelButtons[2].sceneName);
    }
    public void LoadLevel4Tute()
    {
        SceneManager.LoadScene(levelButtons[3].sceneName);
    }
}