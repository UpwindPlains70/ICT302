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
}