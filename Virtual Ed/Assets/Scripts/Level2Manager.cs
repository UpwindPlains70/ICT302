using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level2Manager : MonoBehaviour
{
    [SerializeField]
    SnapToLocation redSnap;

    [SerializeField]
    SnapToLocation greenSnap;

    [SerializeField]
    SnapToLocation blueSnap;

    private float time;
    private float timeGiven;
    private float timeTakenForPastLevels;
    private int score = 0;
    private int maxScore = 0;

    private GameManager GMScript;
    private Level prevLevel;
    public int currLevel = 0;

    public TextMeshProUGUI timerTxt;
    public TextMeshProUGUI scoreTxt;


    public GameObject HUD;
    //Game over variables
    public GameObject gameOverCanvas;
    public int goodScore = 100;
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI finalTime;
    public TextMeshProUGUI goodMsg;
    public TextMeshProUGUI badMsg;

    public bool gameOver = false;

    //Real half life of ~4.8 minutes
    private float halfLife;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        GMScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //level 3 & 4 (zero base)
        prevLevel = GMScript.GetLevel(2);

        //Get level time limit
        halfLife = timeGiven = time = GMScript.GetLevel(currLevel).TimeLimit;
        //Get time taken to reach current level
        timeTakenForPastLevels = GMScript.totalTimeTaken();

            //Max number of proteins to build (5 protiens per nano particle
        maxScore = (GMScript.GetLevel(0).Score / 2) + GMScript.GetLevel(currLevel).Bonus;
        scoreTxt.text = "Score: " + score + " / " + maxScore;
    }

    // Update is called once per frame
    void Update()
    {
        updateTimer();
        //conditions for game over screen
        if ((time <= 0 || score >= maxScore / 2) && gameOver)
            GameOver();
        else if ((time <= 0 || score >= maxScore / 2) && !gameOver)
            UpdateGameManager();

        OnSnapped();
        scoreTxt.text = "Score: " + score + " / " + maxScore;
    }

    private void OnSnapped()
    {
        if (redSnap.Snapped && greenSnap.Snapped && blueSnap.Snapped)
        {
            ++score;
            scoreTxt.text = "Score: " + score + " / " + maxScore;

            redSnap.DestroySnappedObject();
            greenSnap.DestroySnappedObject();
            blueSnap.DestroySnappedObject();

            redSnap.Snapped = greenSnap.Snapped = blueSnap.Snapped = false;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;

        //Disable in-game UI
        HUD.SetActive(false);

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
        if (score == maxScore)
            goodMsg.gameObject.SetActive(true);
        else
            badMsg.gameObject.SetActive(true);

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

            //Reduce max score based on nano particle half life
        if(time < halfLife && maxScore > score)
        {
            halfLife -= 0.5f;
            --maxScore;
        }
        time -= Time.deltaTime;
    }
}
