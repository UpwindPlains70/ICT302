using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Manager : MonoBehaviour
{
    private float time;
    private float timeTakenForPastLevels;
    //private int score = 0;

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

        scoreTxt.text = "Score: " + score;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateTimer();
     
        if (time <= 0)
            GameOver();
    }
        //Place on weapon collider***************************
    public int pointsGood;
    public int pointsBad;

    private int score = 0;
    public Level1Manager lvlManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GoodParticle"))
            score += pointsGood;
        else
            score -= pointsBad;


        lvlManager.scoreTxt.text = "Score: " + score;
    }
        //************************************************

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
