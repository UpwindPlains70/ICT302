using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level4Manager : MonoBehaviour
{
    private int ammo;
    private float time;
    private float timeTakenForPastLevels;
    private int score = 0;

    private GameManager GMScript;
    private Level prevLevel;
    public int currLevel = 3;

    public Text gameOver;
    public Text timerTxt;
    public Text scoreTxt;

    // Start is called before the first frame update
    void Awake()
    {
        GMScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            //level 3 & 4 (zero base)
        prevLevel = GMScript.GetLevel(2);

            //Calc ammo for current level based on previous levels score (with bonus)
        ammo = GMScript.GetLevel(currLevel).Bonus + prevLevel.Score;
            //Get level time limit
        time = GMScript.GetLevel(currLevel).TimeLimit;
            //Get time taken to reach current level
        timeTakenForPastLevels = GMScript.totalTimeTaken();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateTimer();
        if (time <= 0 && Time.timeScale != 0)
            GameOver();

        scoreUpdate();
    }

    void scoreUpdate()
    {
            //Reset every re-calc
        score = 0;
        GameObject[] bCells = GameObject.FindGameObjectsWithTag("B-Cell");
        foreach(GameObject g in bCells)
        {
            if(g.GetComponent<BCell_handle>().isActive())
            {
                ++score;
            }
        }
        scoreTxt.text = "Score: " + score;
    }

    public int getAmmo()
    {
        return ammo;
    }

    public float getGivenTime()
    {
        return time;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        //Destroy all bullets if any

        //Disable in-game UI
        Debug.Log("Game Over");

        //Display scoreboard
        gameOver.gameObject.SetActive(true);

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
            GMScript.addToServer();
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
