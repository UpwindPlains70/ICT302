using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level1Manager : MonoBehaviour
{
    private float time;
    public int Score { get; set; }

    private GameManager GMScript;
    public int currLevel = 0;

    public TextMeshProUGUI timerTxt;
    public TextMeshProUGUI scoreTxt;

    public GameObject HUD;
    //Game over variables
    public GameObject gameOver;
    public int goodScore = 100;
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI goodMsg;
    public TextMeshProUGUI badMsg;

    // Start is called before the first frame update
    void Awake()
    {
        GMScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        //Get level time limit
        time = GMScript.GetLevel(currLevel).TimeLimit;

        scoreTxt.text = "Score: " + Score;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateTimer();

        if (time <= 0)
            GameOver();
    }

    public void GameOver()
    {
        Time.timeScale = 0;

        HUD.SetActive(false);

        //Disable in-game UI
        gameOver.SetActive(true);

        finalScore.SetText("Final Score\n" + Score);

        if (Score > goodScore)
            goodMsg.gameObject.SetActive(true);
        else
            badMsg.gameObject.SetActive(true);

        //Update gameManager
        float timeLimit = GMScript.GetLevel(currLevel).TimeLimit;
        //Update level score in game manager
        GMScript.GetLevel(currLevel).Score = Score;
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

        timerTxt.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);

        time -= Time.deltaTime;
    }
}
