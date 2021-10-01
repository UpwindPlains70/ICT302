using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Manager : MonoBehaviour
{

    private float time;
    private float timeTakenForPastLevels;
    private int score = 0;
    private int maxScore = 0;

    private GameManager GMScript;
    private Level prevLevel;
    public int currLevel = 0;

    public Text timerTxt;
    public Text scoreTxt;

    // Start is called before the first frame update
    void Awake()
    {
        GMScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //level 3 & 4 (zero base)
        prevLevel = GMScript.GetLevel(2);

        //Get level time limit
        time = GMScript.GetLevel(currLevel).TimeLimit;
        //Get time taken to reach current level
        timeTakenForPastLevels = GMScript.totalTimeTaken();

            //Max number of proteins to build
        maxScore = GMScript.GetLevel(0).Score + GMScript.GetLevel(0).Score;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateTimer();

        if (time <= 0)
            GameOver();
    }

    //Spawn protein components (on Spawner), fixed amount available at all times???
        //CODE...

    void OnProtienFormed() //Moved to OnProtienFormed func
    {
        score++;
        scoreTxt.text = "Score: " + score + " / " + maxScore;
    }


    public void GameOver()
    {
        //Disable in-game UI
        Debug.Log("Level Over");

        //Update gameManager
        float timeLimit = GMScript.GetLevel(currLevel).TimeLimit;
        //Update level score in game manager
        GMScript.GetLevel(currLevel).Score = score;
        //update completion time in game manager
        GMScript.GetLevel(currLevel).CompletionTime = (time > 0) ? timeLimit - time : timeLimit;

        //Save data to server (can bo done in game manager)
        if (GMScript.GameOver == false)
        {
            GMScript.GameOver = true;
            //GMScript.addToServer();
        }
    }

    void updateTimer()
    {
        int d = (int)(time * 100.0f);
        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;

        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        time -= Time.deltaTime;
    }
}
