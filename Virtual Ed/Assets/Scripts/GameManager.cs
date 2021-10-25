using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string StudentNumber { get; set; }

    public ulong GameID { get; set; }

    public int getTotalLevels() { return levels.Capacity; }

    private DBInterface DBScript;

    private static GameManager comp;
    [SerializeField]
    private List<Level> levels = new List<Level>();

    public static GameManager _Components
    {
        get
        {
            return comp;
        }
    }

    private bool gameOver = false;

    public bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    public int currLevelIndex = 0;
    private float currLevelTime;
    private float time;
    private bool loading = false;

    //Allows play button to access its properties (i.e. for activation)
    public AsyncOperation asyncLoad { get; private set; }
    public bool MainMenu = false;

    private Scene currScene;
    public bool autoLoading { get; set; }
    public bool singleplayer { get; set; }
    public bool multiplayer { get; set; }

    private void Awake()
    {
        currScene = SceneManager.GetActiveScene();
        currLevelTime = levels[currLevelIndex].TimeLimit;
        loading = false;
        if (comp == null)
        {
            comp = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (comp != this)
                Destroy(gameObject);
        }

        DBScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DBInterface>();


    }

    private void Update()
    {
        if (MainMenu && !loading)
        {
            //StartCoroutine(LoadFirstLevelAsyncScene());
        }
        else if (autoLoading)
        {
            time += Time.deltaTime;
            if (time >= (currLevelTime / 3) && !loading)
            {
                StartCoroutine(LoadAsyncScene());
            }
        }
    }

    public void addToServer()
    {
        //add all level information to server
        DBScript.ReceiveScoreLvlOne();
        Debug.Log("Level data Saved");
    }

    public float totalTimeTaken()
    {
        float totalTime = 0;
        //negative 1 to exclude level 4
        for (int i = 0; i < levels.Count - 1; ++i)
        {
            totalTime += levels[i].TimeLimit;
        }
        return totalTime;
    }
    public float getFullCompletionTime()
    {
        float totalTime = 0;
        //loop through all levels for grand total time
        foreach (Level lvl in levels)
            totalTime += lvl.TimeLimit;

        return totalTime;
    }

    public float totalGivenTime()
    {
        float totalTime = 0;
        for (int i = 0; i < levels.Count - 1; ++i)
        {
            totalTime += levels[i].TimeLimit;
        }
        return totalTime;
    }

    public Level GetLevel(int n)
    {
        return levels[n];
    }

    public void LoadFirstLevel()
    {
        StartCoroutine(LoadFirstLevelAsyncScene());
        asyncLoad.allowSceneActivation = true;
        MainMenu = false;
        loading = false;
    }

    private IEnumerator LoadFirstLevelAsyncScene()
    {
        loading = true;
        asyncLoad = SceneManager.LoadSceneAsync(levels[currLevelIndex].SceneName);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private IEnumerator LoadAsyncScene()
    {
        ++currLevelIndex;
        loading = true;
        asyncLoad = SceneManager.LoadSceneAsync(levels[currLevelIndex].SceneName);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {

            yield return null;
        }

    }

    public void LoadNextScene()
    {
        if (autoLoading)
        {
            loading = false;
            currLevelTime = levels[currLevelIndex].TimeLimit;
            asyncLoad.allowSceneActivation = true;
        }
    }
}
