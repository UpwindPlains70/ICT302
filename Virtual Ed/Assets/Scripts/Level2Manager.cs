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
    private float timeTakenForPastLevels;
    private int score = 0;
    private int maxScore = 0;

    private GameManager GMScript;
    private Level prevLevel;
    public int currLevel = 0;

    public TextMeshProUGUI timerTxt;
    public TextMeshProUGUI scoreTxt;

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
        maxScore = (GMScript.GetLevel(0).Score / 5) + GMScript.GetLevel(0).Bonus;
        scoreTxt.text = "Score: " + score + " / " + maxScore;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateTimer();

        if (time <= 0)
            GameOver();
        OnSnapped();
    }

    /*private void OnEnable()
    {
        redSnap.OnSnapped += OnSnapped;
        greenSnap.OnSnapped += OnSnapped;
        blueSnap.OnSnapped += OnSnapped;
    }

    private void OnDisable()
    {
        redSnap.OnSnapped -= OnSnapped;
        greenSnap.OnSnapped -= OnSnapped;
        blueSnap.OnSnapped -= OnSnapped;
    }*/

    private void OnSnapped()
    {
        if (redSnap.Snapped && greenSnap.Snapped && blueSnap.Snapped)
        {
            //Debug.Log("enter");
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

        timerTxt.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);

        time -= Time.deltaTime;
    }
}
