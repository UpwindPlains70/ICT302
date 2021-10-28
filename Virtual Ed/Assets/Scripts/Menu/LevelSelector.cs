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

    private AsyncOperation asyncLoad;
    void Start()
    {
        //on start
        //we hook the load scene function to each button's onClick event

        /*foreach (LevelButton levelButton in levelButtons)
        {
            levelButton.button.onClick.AddListener(() => LoadScene(levelButton)); //lambda function basically allows us to pre-fill in the function's arguments
        }*/
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            SceneLoad(levelButtons[0]);

    }
    
    private void SceneLoad(LevelButton data)
    {
        StartCoroutine(asyncLoadScene(data));

        asyncLoad.allowSceneActivation = true;
    }

    private IEnumerator asyncLoadScene(LevelButton data)
    {
        asyncLoad = SceneManager.LoadSceneAsync(data.sceneName);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    void LoadScene(LevelButton data)
    {
        SceneManager.LoadScene(data.sceneName);
    }

    public void LoadLevel1Tute()
    {
        StartCoroutine(asyncLoadScene(levelButtons[0]));

        asyncLoad.allowSceneActivation = true;
    }
    public void LoadLevel2Tute()
    {
        StartCoroutine(asyncLoadScene(levelButtons[1]));

        asyncLoad.allowSceneActivation = true;
    }
    public void LoadLevel3Tute()
    {
        StartCoroutine(asyncLoadScene(levelButtons[2]));

        asyncLoad.allowSceneActivation = true;
    }
    public void LoadLevel4Tute()
    {
        StartCoroutine(asyncLoadScene(levelButtons[3]));

        asyncLoad.allowSceneActivation = true;
    }
}