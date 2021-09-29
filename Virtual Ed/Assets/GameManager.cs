using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ulong StudentNumber { get; set; }

    public ulong GameID { get; set; }

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

    public bool GameOver { 
        get { return gameOver; }
        set { gameOver = value; }
    }

    private int currLevelIndex = 0;
    private float currLevelTime;
    private float time;
    private bool loading = false;

        //Allows play button to access its properties (i.e. for activation)
    public AsyncOperation asyncLoad { get; private set; }
    public bool MainMenu = false;

    private Scene currScene;
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
    }

    private void Update()
    {
        if(MainMenu)
        { 
            StartCoroutine(LoadFirstLevelAsyncScene());
        }

        if (currScene.buildIndex != 0)
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
        Debug.Log("Level data Saved");
    }

    public float totalTimeTaken()
    {
        float totalTime = 0;
        foreach (Level lvl in levels)
            totalTime += lvl.CompletionTime;

        return totalTime;
    }

    public float totalGivenTime()
    {
        float totalTime = 0;
        foreach (Level lvl in levels)
            totalTime += lvl.TimeLimit;

        return totalTime;
    }

    public Level GetLevel(int n)
    {
        currLevelIndex = n;
        return levels[n];
    }

    public void LoadFirstLevel()
    {
        asyncLoad.allowSceneActivation = true;
        MainMenu = false;
    }

    private IEnumerator LoadFirstLevelAsyncScene()
    {
        MainMenu = false;
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
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levels[currLevelIndex].SceneName);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (time >= currLevelTime)
            {
                currLevelTime = levels[currLevelIndex].TimeLimit;
                time = 0;
                loading = false;
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }

    }
}
