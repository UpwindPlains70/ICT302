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
    public bool tutorial = false;

    public GameObject HUD;
    //Game over variables
    public GameObject gameOverCanvas;
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI finalTime;
    public TextMeshProUGUI goodMsg;
    public TextMeshProUGUI badMsg;

    public AudioSource myAudio;
    public int delayGameStart;
    private float preLevelTimer;
    private float timeGiven;

    int ballCount;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        GMScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //level 3 & 4 (zero base)
        prevLevel = GMScript.GetLevel(1);

        //Get level time limit
        timeGiven = time = GMScript.GetLevel(currLevel).TimeLimit;

            //store score from previous level
        score = prevLevel.Score;
            //Add bonus to score
        score += prevLevel.Bonus;

            //Display starting score
        currScoreTxt.text = "Score: " + score;
    }
    private void Start()
    {
        if (tutorial == false)
        {
            myAudio.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        preLevelTimer += Time.deltaTime;
        if (delayGameStart < preLevelTimer)
        {
            ballCount = GameObject.FindGameObjectsWithTag("Ball").Length;

            updateTimer();

            if ((time <= 0 || ballCount <= 0) && gameOver)
                GameOver();
            else if ((time <= 0 || ballCount <= 0) && !gameOver)
                UpdateGameManager();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        //Disable in-game UI
        HUD.SetActive(false);
        //Disable in-game UI

        gameOverCanvas.SetActive(true);

        finalScore.SetText("Final Score\n" + score);
        //Final time for level
        int d;
        if (time <= 0)
            d = (int)(timeGiven * 100.0f);
        else
            d = (int)((timeGiven - time) * 100.0f);

        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;

        finalTime.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);

        //Display success or failure message based on score
        if (score >= 5)
            goodMsg.gameObject.SetActive(true);
        else
            badMsg.gameObject.SetActive(true);

        UpdateGameManager();

        //Save data to server (can bo done in game manager)
        if (GMScript.GameOver == true && tutorial == true && score >= 5)
        {
            GMScript.GameOver = false;
            GMScript.addToServer(tutorial);
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
