using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level3Manager : MonoBehaviour
{

    private float time;
    public int score = 0;

    private GameManager GMScript;
    private Level prevLevel;
    public int currLevel = 0;

    public TextMeshProUGUI timerTxt;
    public TextMeshProUGUI currScoreTxt;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Awake()
    {
        GMScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //level 3 & 4 (zero base)
        prevLevel = GMScript.GetLevel(1);

        //Get level time limit
        time = GMScript.GetLevel(currLevel).TimeLimit;

            //store score from previous level
        score = prevLevel.Score;
            //Add bonus to score
        score += prevLevel.Bonus;

            //Display starting score
        currScoreTxt.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        updateTimer();

        if ((time <= 0 || score <= 0) && gameOver)
            GameOver();
        else if ((time <= 0 || score <= 0) && !gameOver)
            UpdateGameManager();
    }

    public void GameOver()
    {
        //Disable in-game UI
        Debug.Log("Level Over");

        UpdateGameManager();

        //Save data to server (can bo done in game manager)
        if (GMScript.GameOver == false)
        {
            GMScript.GameOver = true;
            //GMScript.addToServer();
        }
    }
    //store end level values in game manager
    private void UpdateGameManager()
    {
        //Update gameManager
        float timeLimit = GMScript.GetLevel(currLevel).TimeLimit;
        //Update level score in game manager
        GMScript.GetLevel(currLevel).Score = score;
        //update completion time in game manager
        GMScript.GetLevel(currLevel).CompletionTime = (time > 0) ? timeLimit - time : timeLimit;

        GMScript.LoadNextScene();
    }

    void updateTimer()
    {
        int d = (int)(time * 100.0f);
        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;

        timerTxt.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);

        time -= Time.deltaTime;
    }
}
