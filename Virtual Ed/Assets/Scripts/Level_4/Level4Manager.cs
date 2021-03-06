using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level4Manager : MonoBehaviour
{
    public int ammo { get; set; }
    private float time;
    private float timeTakenForPastLevels;
    private int score = 0;

    private GameManager GMScript;
    private Level prevLevel;
    public int currLevel = 3;

    public Canvas gameOverCanvas;
    public GameObject HUDCanvas;
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI finalTime;
    public TextMeshProUGUI victoryMessage;
    public TextMeshProUGUI retryMessage;
    public TextMeshProUGUI timerTxt;
    public TextMeshProUGUI scoreTxt;

    public bool gameOver = false;
    public bool tutorial = false;

    public AudioSource myAudio;
    public int delayGameStart;
    private float preLevelTimer;
    private bool dataSaved = false;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
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
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        preLevelTimer += Time.deltaTime;
        if (delayGameStart < preLevelTimer)
        {
            updateTimer();
            if ((time <= 0 || ammo <= 0) && gameOver && bullets.Length == 0)
                GameOver();

            scoreUpdate();
        }
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

    public float getGivenTime()
    {
        return time;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        //Destroy all bullets if any

        HUDCanvas.SetActive(false);

        //Display scoreboard
        gameOverCanvas.gameObject.SetActive(true);

        finalScore.SetText("Final Score\n" + score);

        UpdateGameManager();

        int d = (int)(GMScript.GetLevel(currLevel).CompletionTime * 100.0f);

        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;

        finalTime.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);

        int prevLevelScore = GMScript.GetLevel(currLevel - 1).Score + GMScript.GetLevel(currLevel - 1).Bonus;

        if (score >= prevLevelScore / 2)
            victoryMessage.gameObject.SetActive(true);
        else
            retryMessage.gameObject.SetActive(true);

        //Save data to server (can bo done in game manager)
        if (dataSaved == false)
        {            
            dataSaved = true;
                //only add to server if tutorial score is above / equal to required
            if(tutorial == true && score >= prevLevelScore / 2)
                GMScript.addToServer(tutorial);
            else if(tutorial == false)  //add to server if not tutorial
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
